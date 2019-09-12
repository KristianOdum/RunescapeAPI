using System;
using Runescape.Account;

namespace Runescape.Tools{
    public class CsvApiPrinter{
        private Player _player;
        
        public CsvApiPrinter(Player player) {
            _player = player;
        }
        
        public void PrintStatstoCSV() {
            Console.WriteLine(GetPlatform());
            //System.IO.File.WriteAllText(@"",_player.Api);
        }

        private string GetPlatform() {
            return System.Environment.OSVersion.ToString();
        }
    }
}