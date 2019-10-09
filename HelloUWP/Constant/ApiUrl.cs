using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelloUWP.Constant
{
    class ApiUrl
    {
        public static string BASE_URL = "https://2-dot-backup-server-003.appspot.com/_api/v2";
        public static string LOGIN_URL = BASE_URL + "/members/authentication";
        public static string INFORMATION_URL = BASE_URL + "/members/information";
        public static string GET_FREE_SONG_URL = BASE_URL + "/songs/get-free-songs";
        public static string POST_FREE_SONG_URL = BASE_URL + "/songs/post-free";
    }
}
