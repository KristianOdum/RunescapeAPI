using System;
using System.Net;
using Runescape.Account;
using Runescape.Tools;

namespace Runescape{
    
    internal class Program{
        public static void Main(string[] args) {
            string username = "ironodum";
            string accountType = "ironman";
            Player player = new Player(username, accountType);
            
            CsvApiPrinter csv = new CsvApiPrinter(player);
            csv.PrintStatsToCsvDropbox();
        }
    }
}