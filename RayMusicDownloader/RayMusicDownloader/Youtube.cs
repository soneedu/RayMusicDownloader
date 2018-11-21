using System;
using System.Data;
using System.Diagnostics;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace MusicDownloader
{
    public class Youtube
    {
        public static async Task Download(string playlistId, string apiKey, DataTable viedoDt)
        {
            try
            {
                var playListNameTask = GetPlayListNameAsync(playlistId, apiKey);

                var url = string.Format($"https://www.googleapis.com/youtube/v3/playlistItems?part=contentDetails,id,snippet,status&playlistId={playlistId}&maxResults=50&key={apiKey}");

                dynamic result = await GetResult(url);

                var playlistName = await playListNameTask;

                Console.WriteLine($"Playlist: {playlistName}");
                Console.WriteLine($"{result?.pageInfo?.totalResults} videos in playlist.");
                Console.WriteLine("-----------------------------------------------------\n");

                var i = 0;
                foreach (var video in result.items)
                {
                    i++;
                    Console.WriteLine($"{i}. {video.snippet.title}");

                    viedoDt.Rows.Add(i, video.snippet.title.ToString(), video.snippet.resourceId.videoId.ToString());

                }
                var nextPageToken = result.nextPageToken;
                while (nextPageToken != null)
                {
                    dynamic subresult = await GetResult(url + "&pageToken=" + nextPageToken);

                    foreach (var video in subresult.items)
                    {
                        i++;
                        Console.WriteLine($"{i}. {video.snippet.title}");

                        viedoDt.Rows.Add(i, video.snippet.title.ToString(), video.snippet.resourceId.videoId.ToString());

                    }

                    nextPageToken = subresult.nextPageToken;
                }

            }
            catch (Exception ex)
            {
                Debugger.Break();
                Console.WriteLine(ex.Message);
            }
        }

        public static async Task<string> GetPlayListNameAsync(string playlistId, string apiKey)
        {
            string playlistName = null;

            try
            {
                var url = string.Format($"https://www.googleapis.com/youtube/v3/playlists?part=snippet,id&id={playlistId}&key={apiKey}");

                dynamic result = await GetResult(url);

                playlistName = result?.items?[0]?.snippet.title;
            }
            catch (Exception ex)
            {
                Debugger.Break();
                Console.WriteLine(ex.Message);
            }

            return playlistName;
        }

        public static async Task<dynamic> GetResult(string url)
        {
            dynamic result = null;

            try
            {
                var client = new HttpClient();

                var json = await client.GetStringAsync(url);

                result = JsonConvert.DeserializeObject(json);
            }
            catch (Exception ex)
            {
                Debugger.Break();
                Console.WriteLine(ex.Message);
            }

            return result;
        }
    }
}