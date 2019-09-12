using System;
using System.Collections.Generic;
using Runescape.Tools;
using System.IO;

namespace Runescape.Account{
    public class Player{
        public readonly string Username;
        public readonly string AccountType;
        public List<Skill> Stats = new List<Skill>();
        public string Api;
        
        public Player(string username, string accountType = "normal") {
            Username = username;
            AccountType = accountType;
            LoadStats();
        }

        private void LoadStats() {
            HighscoreAPI api = new HighscoreAPI(this);
            Api = api.PlayerAPI;
            
            string[] skillSet = Api.Split(',', '\n');
            
            for (int i = 0, j = 0; i < Constants.SkillCount; i++) {
                Stats.Add(new Skill());
                Stats[i].SkillName = Constants.SkillNames[i];
                Stats[i].Rank = long.Parse(skillSet[j++]);
                Stats[i].Level = long.Parse(skillSet[j++]);
                Stats[i].XP = long.Parse(skillSet[j++]);
            }
        }

        public void PrintStats() {
            for (int i = 0; i < Constants.SkillCount; i++) {
                Console.WriteLine(Stats[i].SkillName.PadRight(12) + " " + 
                                  Stats[i].Rank.ToString().PadLeft(7) + " " +
                                  Stats[i].Level.ToString().PadLeft(4) + " " +
                                  Stats[i].XP.ToString("#,##0").PadLeft(13));
            }
        }
    }
}