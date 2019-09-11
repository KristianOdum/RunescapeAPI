using System.Net.Http;

namespace Runescape{
    public class XpTracker{
        public void UpdateCrystalMathLabs(string username) {
            httpclient request = (HttpWebRequest) WebRequest.Create(
                "https://crystalmathlabs.com/tracker/update.php?player=ironodum");
            request.
        }
    }
}