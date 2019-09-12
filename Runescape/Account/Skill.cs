namespace Runescape.Account{
    public class Skill{
        public string SkillName;
        public long Rank;
        public long Level;
        public long XP;

        public override string ToString() {
            return Rank + " " + Level + " " + ((double)XP / 1000000).ToString("0.0") + "M";
        }
    }
}