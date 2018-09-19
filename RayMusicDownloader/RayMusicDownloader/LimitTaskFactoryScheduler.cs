using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace MusicDownloader
{
    public class LimitedConcurrencyLevelTaskScheduler : TaskScheduler
    {
        // Indicates whether the current thread is processing work items.
        [ThreadStatic]
        private static bool _currentThreadIsProcessingItems;

        // The list of tasks to be executed 
        private readonly LinkedList<Task> _tasks = new LinkedList<Task>(); // protected by lock(_tasks)

        // The maximum concurrency level allowed by this scheduler. 
        private readonly int _maxDegreeOfParallelism;

        // Indicates whether the scheduler is currently processing work items. 
        private int _delegatesQueuedOrRunning = 0;

        // Creates a new instance with the specified degree of parallelism. 
        public LimitedConcurrencyLevelTaskScheduler(int maxDegreeOfParallelism)
        {
            if (maxDegreeOfParallelism < 1) throw new ArgumentOutOfRangeException("maxDegreeOfParallelism");
            _maxDegreeOfParallelism = maxDegreeOfParallelism;
        }

        // Queues a task to the scheduler. 
        protected sealed override void QueueTask(Task task)
        {
            // Add the task to the list of tasks to be processed.  If there aren't enough 
            // delegates currently queued or running to process tasks, schedule another. 
            lock (_tasks)
            {
                _tasks.AddLast(task);
                if (_delegatesQueuedOrRunning < _maxDegreeOfParallelism)
                {
                    ++_delegatesQueuedOrRunning;
                    NotifyThreadPoolOfPendingWork();
                }
            }
        }

        // Inform the ThreadPool that there's work to be executed for this scheduler. 
        private void NotifyThreadPoolOfPendingWork()
        {
            ThreadPool.UnsafeQueueUserWorkItem(_ =>
            {
                // Note that the current thread is now processing work items.
                // This is necessary to enable inlining of tasks into this thread.
                _currentThreadIsProcessingItems = true;
                try
                {
                    // Process all available items in the queue.
                    while (true)
                    {
                        Task item;
                        lock (_tasks)
                        {
                            // When there are no more items to be processed,
                            // note that we're done processing, and get out.
                            if (_tasks.Count == 0)
                            {
                                --_delegatesQueuedOrRunning;
                                break;
                            }

                            // Get the next item from the queue
                            item = _tasks.First.Value;
                            _tasks.RemoveFirst();
                        }

                        // Execute the task we pulled out of the queue
                        base.TryExecuteTask(item);
                    }
                }
                // We're done processing items on the current thread
                finally { _currentThreadIsProcessingItems = false; }
            }, null);
        }

        // Attempts to execute the specified task on the current thread. 
        protected sealed override bool TryExecuteTaskInline(Task task, bool taskWasPreviouslyQueued)
        {
            // If this thread isn't already processing a task, we don't support inlining
            if (!_currentThreadIsProcessingItems) return false;

            // If the task was previously queued, remove it from the queue
            if (taskWasPreviouslyQueued)
                // Try to run the task. 
                if (TryDequeue(task))
                    return base.TryExecuteTask(task);
                else
                    return false;
            else
                return base.TryExecuteTask(task);
        }

        // Attempt to remove a previously scheduled task from the scheduler. 
        protected sealed override bool TryDequeue(Task task)
        {
            lock (_tasks) return _tasks.Remove(task);
        }

        // Gets the maximum concurrency level supported by this scheduler. 
        public sealed override int MaximumConcurrencyLevel { get { return _maxDegreeOfParallelism; } }

        // Gets an enumerable of the tasks currently scheduled on this scheduler. 
        protected sealed override IEnumerable<Task> GetScheduledTasks()
        {
            bool lockTaken = false;
            try
            {
                Monitor.TryEnter(_tasks, ref lockTaken);
                if (lockTaken) return _tasks;
                else throw new NotSupportedException();
            }
            finally
            {
                if (lockTaken) Monitor.Exit(_tasks);
            }
        }
    }

    public class UseTaskFactory
    {
        public delegate void TaskFactoryFucDelegate(object parameter);
        public static CancellationTokenSource Cts = new CancellationTokenSource();
        // 通过Task Factory和Schedule来控制线程的数量
        public static void initail_TaskFactory(object parameter, TaskFactoryFucDelegate myFuc)
        {
            var thisparameter = parameter as List<object>;
            var IPs = thisparameter[0] as string[];
            var CMDs = thisparameter[1] as string[];
            var index = int.Parse(thisparameter[2].ToString());
            var ipList = IPs;

            //启用多个后台多线程进行运算加快速度
            //定义字DT的最大行数，用来拆分整个DT，同时并发4个线程来跑。行数=总数/4
            var cpuCores = Environment.ProcessorCount;
            int maxLength = 1, maxThread = cpuCores;
            //计算总共跑多少个任务,Channels
            var channels = ipList.Length / maxLength + (ipList.Length % maxLength > 0 ? 1 : 0);
            //总共要进行几个times的任务调度，一次任务跑maxThread个线程
            var times = channels / maxThread + (channels % maxThread > 0 ? 1 : 0);

            #region DoTask by using TaskFactory
            //int index =0;
            // 使用TaskFactory进行并行任务操作
            var scheduler = new LimitedConcurrencyLevelTaskScheduler(maxThread);
            var factory = new TaskFactory(scheduler);
            for (int j = 0; j < times; j++)
            {
                var k = j;
                var currChannel = Math.Min(maxThread, channels - j * maxThread);

                for (var i = 0; i < currChannel; i++)
                {
                    //根据分组，去除要执行的列表，由于是单个单个设备处理，传递的是要IP字符串
                    var thisIPList = ipList.Skip((i + j * maxThread) * maxLength).Take(maxLength).ToArray();
                    var indexList = CMDs.Skip((i + j * maxThread) * maxLength).Take(maxLength).ToArray();
                    //初始化要传递到执行函数的参数组
                    var threeParaMeter = new List<object>{thisIPList, indexList, index.ToString()};
                    // 要执行的IP从列表中去除IP字符串
                    //要执行的命令
                    //CancelToken，为了在子线程进行控制是否退出该Task
                    // threeParameter.Add(index.ToString());
                    factory.StartNew(() => myFuc(threeParaMeter), Cts.Token);
                    index++;
                }
            }

            #endregion

        }

    }
}