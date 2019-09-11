namespace Runescape{
    public class Skill{
        public string SkillName;
        public long Rank;
        public long Level;
        public long XP;

        public override string ToString() {
            return Rank.ToString() + " " + Level.ToString() + " " + ((double)XP / 1000000).ToString("0.0") + "M";
        }
    }
}