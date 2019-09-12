using System;
using System.Linq;
using System.IO;
using System.Net;
using System.Runtime.CompilerServices;
using Runescape.Account;

namespace Runescape.Tools{
    public class CsvApiPrinter{
        private readonly Player _player;
        
        public CsvApiPrinter(Player player) {
            _player = player;
        }
        
        public void PrintStatsToCsv() {
            string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) +
                    "/" + _player.Username + "_" + "stats.csv";
            File.WriteAllLines(path,_player.Stats.Select(p => p.ToCsvString()));
        }

        public void PrintStatsToCsvDropbox() {
            string path = GetDropboxPath();
            File.WriteAllLines(path,_player.Stats.Select(p => p.ToCsvString()));
        }

        public string GetDropboxPath() {
            string pathToConfig = Environment.GetFolderPath(Environment.SpecialFolder.Programs) + "/runescapeapiconfig.txt";
            string pathToDropbox;
            
            if (File.Exists(pathToConfig)) {
                pathToDropbox = File.ReadAllText(pathToConfig);
            }
            else {
                Console.WriteLine("Could not find config file for dropbox. Please specify the path to dropbox:");
                pathToDropbox = Console.ReadLine() + "/runescapeapiconfig.txt";
            }

            return pathToDropbox;
        }
    }
}