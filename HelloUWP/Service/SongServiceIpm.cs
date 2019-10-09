using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using HelloUWP.Constant;
using HelloUWP.Entity;
using HelloUWP.Pages;
using Newtonsoft.Json;

namespace HelloUWP.Service
{
    class SongServiceIpm : ISongService
    {
        public Song PostSongFree(Song song)
        {
            try
            {
                var httpClient = new HttpClient();
                //httpClient.DefaultRequestHeaders.Add("Authorization", "Basic " + token);
                HttpContent content = new StringContent(JsonConvert.SerializeObject(song), Encoding.UTF8,
                    "application/json");

                Task<HttpResponseMessage> httpRequestMessage = httpClient.PostAsync(ApiUrl.POST_FREE_SONG_URL, content);
                String responseContent = httpRequestMessage.Result.Content.ReadAsStringAsync().Result;
                Debug.WriteLine(responseContent);

                var resSong = JsonConvert.DeserializeObject<Song>(responseContent);
                return resSong;
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
                return null;
            }
            
        }

        public ObservableCollection<Song> GetFreeSongs()
        {
            ObservableCollection<Song> songs = new ObservableCollection<Song>();
            
            // thực hiện request lên api lấy token về.
            var client = new HttpClient();
            var responseContent = client.GetAsync(ApiUrl.GET_FREE_SONG_URL).Result.Content.ReadAsStringAsync().Result;
            songs = JsonConvert.DeserializeObject<ObservableCollection<Song>>(responseContent);
            return songs;
        }
    }
}
