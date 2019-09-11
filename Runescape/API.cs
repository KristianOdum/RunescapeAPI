using System.Net;

namespace Runescape{
    public class API{
        WebClient wc = new WebClient();

        public string GetPlayerAPI(string username, string type = "normal") {
            string APILink;
            string accountType;
            
            if (type == "normal") 
                APILink = "https://secure.runescape.com/m=hiscore_oldschool/index_lite.ws?player=";
            else 
                APILink = "https://secure.runescape.com/m=hiscore_oldschool_" + type +
                                 "/index_lite.ws?player=";
            
            string highscoreAPI = wc.DownloadString(APILink + username);

            return highscoreAPI;
        }
    }
}