using System;
using System.Net;

namespace Runescape{
    
    internal class Program{
        public static void Main(string[] args) {
            string name = "ironodum";
            Player player = new Player(name, "normal");
            player.LoadStatsFromAPI();
            
            player.PrintStats();
            XpTracker.UpdateCrystalMathLabs(name);
        }
    }
}