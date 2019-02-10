using System;
using System.Collections.Generic;
using System.Linq;

namespace AvengersSkillsUSA {
    public class Team {
        public Team(string name) {
            this.Name = name;
            this.Teammates = new List<Avenger>();
        }

        public string Name { get; set; }
        public List<Avenger> Teammates { get; set; }
        public int NumberOfTeammates {
            get {
                return this.Teammates.Count;
            }
        }

        private int GenerateRandomIndex(Random random) {
            const int inclusiveMin = 0; // 0-based index
            int exclusiveMax = this.NumberOfTeammates;
            return random.Next(inclusiveMin, exclusiveMax);
        }

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

        public override string ToString() {
            return this.Name;
        }
    }
}