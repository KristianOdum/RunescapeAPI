using System;
using System.Net;

namespace Runescape{
    
    internal class Program{
        public static void Main(string[] args) {
            Player player = new Player("lynx titan", "normal");
            player.LoadStatsFromAPI();
            
            
        }
    }
}