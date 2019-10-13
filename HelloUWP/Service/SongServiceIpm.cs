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
                string token = GetTokenFromLocalStorage();
                var httpClient = new HttpClient();
                httpClient.DefaultRequestHeaders.Add("Authorization", "Basic " + token);
                HttpContent content = new StringContent(JsonConvert.SerializeObject(song), Encoding.UTF8,
                    "application/json");

                Task<HttpResponseMessage> httpRequestMessage = httpClient.PostAsync(ApiUrl.SONG_URL, content);
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
            string token = GetTokenFromLocalStorage();
            var client = new HttpClient();
            client.DefaultRequestHeaders.Add("Authorization", "Basic " + token);
            var responseContent = client.GetAsync(ApiUrl.SONG_URL).Result.Content.ReadAsStringAsync().Result;
            songs = JsonConvert.DeserializeObject<ObservableCollection<Song>>(responseContent);
            return songs;
        }

        public ObservableCollection<Song> GetMySongs()
        {
            ObservableCollection<Song> mySongs = new ObservableCollection<Song>();
            string token = GetTokenFromLocalStorage();
            var client = new HttpClient();
            client.DefaultRequestHeaders.Add("Authorization", "Basic " + token);
            var responseContent = client.GetAsync(ApiUrl.GET_MY_SONG_URL).Result.Content.ReadAsStringAsync().Result;
            mySongs = JsonConvert.DeserializeObject<ObservableCollection<Song>>(responseContent);
            return mySongs;
        }

        private string GetTokenFromLocalStorage()
        {
            Windows.Storage.StorageFolder storageFolder = Windows.Storage.ApplicationData.Current.LocalFolder;
            Windows.Storage.StorageFile sampleFile = storageFolder.GetFileAsync("sample.txt").GetAwaiter().GetResult();
            String token = Windows.Storage.FileIO.ReadTextAsync(sampleFile).GetAwaiter().GetResult();
            return token;
        }

    }
}
