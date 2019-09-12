namespace Runescape.Account{
    public class Skill{
        public string SkillName;
        public long Rank;
        public long Level;

        private long _xp;

        public long XP {
            get => _xp;
            set {
                _xp = value;
                _formattedXp = ((double) XP / 1000000).ToString("0.0") + "M";
            }
        }

        private string _formattedXp;

        public override string ToString() {
            return Rank + " " + Level + " " + _formattedXp;
        }

        public string ToCsvString() {
            return $"{SkillName},{Rank},{Level},{XP}";
        }
    }
}