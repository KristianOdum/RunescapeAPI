using System;
using System.Linq;
using System.IO;
using System.Net;
using System.Runtime.CompilerServices;
using Runescape.Account;

namespace Runescape.Tools{
    public class CsvApiPrinter{
        private readonly Player _player;
        private readonly string _configPath = Environment.GetFolderPath(Environment.SpecialFolder.Programs) + @"\runescapeapiconfig.txt";
        private const string InsideDropboxPath = @"\Runescape\Ironman\Skilling\";
        private const string OutputFileExtension = "_stats.csv";
        
        public CsvApiPrinter(Player player) {
            _player = player;
        }
        
        public void PrintStatsToCsv() {
            string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) +
                    "/" + _player.Username + OutputFileExtension;
            File.WriteAllLines(path,_player.Stats.Select(p => p.ToCsvString()));
        }

        public void PrintStatsToCsvDropbox() { 
            string path = GetDropboxPath() + InsideDropboxPath + _player.Username + OutputFileExtension;
            File.WriteAllText(path, "\"sep=,\"\n");
            File.AppendAllLines(path, _player.Stats.Select(p => p.ToCsvString()));
        }

        public string GetDropboxPath() {
            string pathToDropbox;
            Console.WriteLine(_configPath);
            
            if (File.Exists(_configPath)) {
                pathToDropbox = File.ReadAllText(_configPath);
            }
            else {
                Console.WriteLine("Could not find config file for dropbox. Please specify the path to dropbox:");
                pathToDropbox = Console.ReadLine();
                File.WriteAllText(_configPath, pathToDropbox);
            }
            
            return pathToDropbox;
        }
    }
}