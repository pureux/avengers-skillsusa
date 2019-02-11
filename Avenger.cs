using System;

namespace AvengersSkillsUSA {

    /// <summary>
    /// An Avenger object with a name, power level, and team
    /// </summary>
    public class Avenger {

        /// <summary>
        /// Initialize an Avenger object
        /// </summary>
        /// <param name="name">The Avenger's name</param>
        /// <param name="powerLevel">The Avenger's power level</param>
        /// <param name="team">The Avenger's team name</param>
        public Avenger(string name, int powerLevel, string team) {
            this.Name = name;
            this.PowerLevel = powerLevel;
            this.Team = team;
        }

        /// <summary>
        /// The Avenger's name
        /// </summary>
        /// <value></value>
        public string Name { get; set; }

        /// <summary>
        /// The Avenger's power level
        /// </summary>
        /// <value></value>
        public int PowerLevel { get; set; }

        /// <summary>
        /// The Avenger's team name
        /// </summary>
        /// <value></value>
        public string Team { get; set; }

        /// <summary>
        /// Override the ToString function to return a semi-unique identifier
        /// </summary>
        /// <returns></returns>
        public override string ToString() {
            return string.Format("{0}|{1}|{2}", this.Name, this.PowerLevel, this.Team);
        }
    }
}