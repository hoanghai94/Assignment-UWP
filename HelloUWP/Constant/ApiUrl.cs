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
        public static string REGISTER_URL = BASE_URL + "/members";
        public static string LOGIN_URL = BASE_URL + "/members/authentication";
        public static string INFORMATION_URL = BASE_URL + "/members/information";
        public static string SONG_URL = BASE_URL + "/songs";
        public static string GET_MY_SONG_URL = BASE_URL + "/songs/get-mine";
    }
}
