using System;
using System.Net;

namespace Runescape{
    public class XpTracker{
        public static void UpdateCrystalMathLabs(string username) {
            HttpWebRequest request = (HttpWebRequest) WebRequest.Create(
                "https://crystalmathlabs.com/tracker/update.php?player=ironodum");
            HttpWebResponse response = (HttpWebResponse) request.GetResponse();
            Console.WriteLine(response.StatusDescription);
        }
    }
}