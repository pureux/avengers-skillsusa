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
        /// <param name="random">A Random object containing a randomized sequence of integers to traverse</param>
        /// <returns></returns>
        private int GenerateRandomIndex(Random random) {
            const int inclusiveMin = 0; // 0-based index
            int exclusiveMax = this.NumberOfTeammates;
            return random.Next(inclusiveMin, exclusiveMax);
        }

        /// <summary>
        /// Randomly select combatants from the list of Avengers on the team
        /// </summary>
        /// <param name="total">The total number of combatants to select on the team</param>
        /// <returns></returns>
        public List<Avenger> SelectCombatants(int total) {
            List<Avenger> combatants = new List<Avenger>();
            Random random = new Random();  // Instantiate one time, outside of the loop; otherwise you'll get the same sequence each time due to the system clock

            while (combatants.Count < total && combatants.Count < this.NumberOfTeammates) {
                int i = GenerateRandomIndex(random);
                Avenger avenger = this.Teammates[i];

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
            List<int> indices = new List<int>();
            Random random = new Random();  // Instantiate one time, outside of the loop; otherwise you'll get the same sequence each time due to the system clock

            while (indices.Count < half) {
                int i = GenerateRandomIndex(random);
                if (!indices.Contains(i)) {
                    indices.Add(i);
                }
            }

            Dictionary<string, bool> results = new Dictionary<string, bool>();
            for (int i = 0; i < this.NumberOfTeammates; i++)
            {
                Avenger avenger = this.Teammates[i];
                bool includedInHalf = indices.Contains(i);
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