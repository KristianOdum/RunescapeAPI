using System;
using System.Net;
using Runescape.Account;

namespace Runescape.Tools{
    public class XpTracker{
        
        public static string Update(Player player) {
            string trackingStatus;
            string a = player.Username.Replace(" ", "+");
            
            HttpWebRequest request = (HttpWebRequest) WebRequest.Create(
                "https://crystalmathlabs.com/tracker/update.php?player=" + a);
            HttpWebResponse response = (HttpWebResponse) request.GetResponse();
            
            if(response.StatusDescription == "OK")
                trackingStatus = player.Username + "'s tracker has been updated.";
            else {
                trackingStatus = "An error occured during tracking update on CrystalMathLabs";
                throw new Exception(trackingStatus);
            }

            return trackingStatus;
        }
    }
}