using System;
using System.Collections.Generic;
using System.Linq;

namespace AvengersSkillsUSA {

    /// <summary>
    /// A team object with a name and teammates (Avengers)
    /// </summary>
    public class Team {

        /// <summary>
        /// Initialize a team object
        /// </summary>
        /// <param name="name"></param>
        public Team(string name) {
            this.Name = name;
            this.Teammates = new List<Avenger>();
        }

        /// <summary>
        /// The team name
        /// </summary>
        /// <value></value>
        public string Name { get; set; }

        /// <summary>
        /// The Avengers in the team
        /// </summary>
        /// <value></value>
        public List<Avenger> Teammates { get; set; }

        /// <summary>
        /// The number of Avengers on the team
        /// </summary>
        /// <value></value>
        public int NumberOfTeammates {
            get {
                return this.Teammates.Count;
            }
        }

        /// <summary>
        /// Generate a new random number based on the number of Avengers on the team
        /// </summary>
        /// <param name="random"></param>
        /// <returns></returns>
        private int GenerateRandomIndex(Random random) {
            const int inclusiveMin = 0; // 0-based index
            int exclusiveMax = this.NumberOfTeammates;
            return random.Next(inclusiveMin, exclusiveMax);
        }

        /// <summary>
        /// Randomly select combatants from the list of Avengers on the team
        /// </summary>
        /// <param name="total"></param>
        /// <returns></returns>
        public List<Avenger> SelectCombatants(int total) {
            var combatants = new List<Avenger>();
            var random = new Random();

            while (combatants.Count < total && combatants.Count < this.NumberOfTeammates) {
                var i = GenerateRandomIndex(random);
                var avenger = this.Teammates[i];

                if (!combatants.Exists(c => c.Name == avenger.Name)) {
                    combatants.Add(avenger);
                }
            }
            return combatants;
        }

        /// <summary>
        /// Randomly separate half of the Avengers from the other and return the entire list
        /// </summary>
        /// <returns></returns>
        public Dictionary<string, bool> BalanceTheTeam() {
            int half = (int)Math.Ceiling((double)this.NumberOfTeammates / (double)2);
            var indices = new List<int>();
            var random = new Random();

            while (indices.Count < half) {
                var i = GenerateRandomIndex(random);
                if (!indices.Contains(i)) {
                    indices.Add(i);
                }
            }

            var results = new Dictionary<string, bool>();
            for (int i = 0; i < this.NumberOfTeammates; i++)
            {
                var avenger = this.Teammates[i];
                var includedInHalf = indices.Contains(i);
                results.Add(avenger.Name, includedInHalf);
            }

            return results;
        }

        /// <summary>
        /// Override the ToString function to return a semi-unique identifier
        /// </summary>
        /// <returns></returns>
        public override string ToString() {
            return this.Name;
        }
    }
}