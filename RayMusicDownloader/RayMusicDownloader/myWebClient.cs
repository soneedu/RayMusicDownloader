using System;
using System.IO;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace MusicDownloader
{
    class myWebClient
    {
        public HttpWebRequest req;
        public CookieCollection curCookies;
        public HttpWebResponse resp;

        public string GetUrl(string url)
        {
            req = (HttpWebRequest) WebRequest.Create(url);
            req.UserAgent = @"Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/68.0.3440.106 Safari/537.36";
            req.AllowAutoRedirect = true;
            req.Timeout = 300000;
            req.CookieContainer = new CookieContainer();
            curCookies = new CookieCollection();
            req.CookieContainer.Add(curCookies);

            resp = (HttpWebResponse) req.GetResponse();
            StreamReader sr = new StreamReader(resp.GetResponseStream());
            string destUrlRespHtml = sr.ReadToEnd();

            return destUrlRespHtml;
        }

        public async Task<String> MakeRequestAsync(String url)
        {
            String responseText = await Task.Run(() =>
            {
                try
                {
                    req = (HttpWebRequest)WebRequest.Create(url);
                    req.UserAgent = @"Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/68.0.3440.106 Safari/537.36";
                    req.AllowAutoRedirect = true;
                    req.Timeout = 100000;
                    req.CookieContainer = new CookieContainer();
                    curCookies = new CookieCollection();
                    req.CookieContainer.Add(curCookies);

                    resp = (HttpWebResponse)req.GetResponse();
                    Stream responseStream = resp.GetResponseStream();
                    return new StreamReader(responseStream).ReadToEnd();
                }
                catch (Exception e)
                {
                    Console.WriteLine("Error: " + e.Message);
                }
                return null;
            });

            return responseText;
        }

        public async Task<String> MakePostAsync(String url,string postStr)
        {
            String responseText = await Task.Run(() =>
            {
                try
                {
                    req = (HttpWebRequest)WebRequest.Create(url);
                    req.UserAgent = @"Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/68.0.3440.106 Safari/537.36";

                    req.AllowAutoRedirect = true;
                    req.Timeout = 100000;
                    req.CookieContainer = new CookieContainer();
                    curCookies = new CookieCollection();
                    req.CookieContainer.Add(curCookies);

                    var postData = postStr;
                    var data = Encoding.ASCII.GetBytes(postData);
                    req.Method = "Post";

                    req.ContentType = "application/x-www-form-urlencoded";
                    req.ContentLength = data.Length;

                    using (var stream = req.GetRequestStream())
                    {
                        stream.Write(data, 0, data.Length);
                    }

                    resp = (HttpWebResponse)req.GetResponse();
                    Stream responseStream = resp.GetResponseStream();
                    return new StreamReader(responseStream).ReadToEnd();

                }
                catch (Exception e)
                {
                    Console.WriteLine("Error: " + e.Message);
                }
                return null;
            });

            return responseText;
        }



    }
}
