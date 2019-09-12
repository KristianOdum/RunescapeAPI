using System;
using System.Linq;
using Runescape.Account;

namespace Runescape.Tools{
    public class CsvApiPrinter{
        private readonly Player _player;
        private string _path;
        
        public CsvApiPrinter(Player player) {
            _player = player;
        }
        
        public void PrintStatsToCsv() {
            _path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) +
                    "/" + _player.Username + "_" + "stats.csv";
            System.IO.File.WriteAllLines(_path,_player.Stats.Select(p => p.ToCsvString()));
        }
    }
}