using System;
using System.Collections.Generic;
using System.Linq;

namespace Runescape{
    public class Player{
        private string _username;
        public string Username {
            get => _username;
            set {
                _username = value;
                _linkUserName = Username.Replace(" ", "%20");
            }
        }

        private string _accountType;
        public string AccountType { 
            get => _accountType;
            set => _accountType = value;
        }

        private string _linkUserName;
        private string _playerAPI;
        public List<Skill> Stats = new List<Skill>();
        
        public Player(string username, string accountType = "normal") {
            Username = username;
            AccountType = accountType;
        }
        
        private void LoadAPI(string linkUsername, string type) {
            API api = new API();
            _playerAPI = api.GetPlayerAPI(linkUsername, type);
        }

        public void LoadStatsFromAPI(bool specificHighscore = true) {
            string type = specificHighscore ? AccountType : "normal";
            LoadAPI(_linkUserName, type);
            string[] skillSet = _playerAPI.Split(new char[]{',', '\n'});
            
            for (int i = 0, j = 0; i < Constants.SkillCount; i++) {
                Stats.Add(new Skill());
                Stats[i].Rank = long.Parse(skillSet[j++]);
                Stats[i].Level = long.Parse(skillSet[j++]);
                Stats[i].XP = long.Parse(skillSet[j++]);
            }
        }

        public void PrintStats() {
            for (int i = 0; i < 24; i++) {
                Console.WriteLine(Constants.SkillNames[i].PadRight(12) + " " + 
                                  Stats[i].Rank.ToString().PadLeft(7) + " " +
                                  Stats[i].Level.ToString().PadLeft(4) + " " +
                                  Stats[i].XP.ToString("#,##0"));
            }
        }
    }
}