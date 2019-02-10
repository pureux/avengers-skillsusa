using System;

namespace AvengersSkillsUSA {
    public class Avenger {
        public Avenger(string name, int powerLevel, string team) {
            this.Name = name;
            this.PowerLevel = powerLevel;
            this.Team = team;
        }

        public string Name { get; set; }
        public int PowerLevel { get; set; }
        public string Team { get; set; }

        public override string ToString() {
            return String.Format("{0}|{1}|{2}", this.Name, this.PowerLevel, this.Team);
        }
    }
}