using System;
using System.Net;
using Runescape.Account;

namespace Runescape.Tools{
    public class HighscoreAPI{
        WebClient wc = new WebClient();
        private string _formattedUsername;
        private string _playerAPIURL;
        public string PlayerAPI;

        public HighscoreAPI(Player player) {
            _formattedUsername = player.Username.Replace(" ", "%20");
            PlayerAPI = GetPlayerAPI(player);
        }

        private string GetPlayerAPI(Player player) {
            if (player.AccountType == "normal") 
                _playerAPIURL = "https://secure.runescape.com/m=hiscore_oldschool/index_lite.ws?player=";
            else 
                _playerAPIURL = "https://secure.runescape.com/m=hiscore_oldschool_" + player.AccountType +
                                 "/index_lite.ws?player=";
            _playerAPIURL += _formattedUsername;

            return wc.DownloadString(_playerAPIURL);
        }
    }
}