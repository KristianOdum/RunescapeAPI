using System;
using System.Net;
using Runescape.Account;

namespace Runescape.Tools{
    public class XpTracker{
        public string TrackingStatus;
        
        public void UpdatePlayer(Player player) {
            string a = player.Username.Replace(" ", "+");
            
            HttpWebRequest request = (HttpWebRequest) WebRequest.Create(
                "https://crystalmathlabs.com/tracker/update.php?player=" + a);
            HttpWebResponse response = (HttpWebResponse) request.GetResponse();
            
            if(response.StatusDescription == "OK")
                TrackingStatus = player.Username + "'s tracker has been updated.";
            else {
                TrackingStatus = "An error occured during tracking update on CrystalMathLabs";
                throw new Exception(TrackingStatus);
            }
        }
    }
}