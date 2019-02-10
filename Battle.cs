using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AvengersSkillsUSA {
    public class Battle {

        public Battle(List<Team> teams, int numberOfCombatantsPerTeam, string tieLabel) {
            this.Results = new Dictionary<string, int>();
            this.Combatants = new List<Avenger>();
            this.Teams = teams;

            foreach (var team in teams) {
                this.Combatants.AddRange(team.SelectCombatants(numberOfCombatantsPerTeam));

                int score = this.CalculateTotalPowerLevel(this.Combatants.Where(c => c.Team == team.Name).ToList());

                this.Results.Add(team.Name, score);
            }

            this.Winner = DetermineWinner(this.Results, tieLabel);
        }

        public string Winner { get; private set; }
        public List<Avenger> Combatants { get; private set; }
        public List<Team> Teams { get; private set; }
        public Dictionary<string, int> Results { get; private set; }

        private int CalculateTotalPowerLevel(List<Avenger> teamCombatants) {
            int totalPowerLevel = 0;

            foreach (Avenger combatant in teamCombatants) {
                totalPowerLevel += combatant.PowerLevel;
            }

            return totalPowerLevel;
        }

        private string DetermineWinner(Dictionary<string, int> results, string tieLabel) {
            var scores = new List<int>(results.Values);
            if (scores.Distinct().Count() <= 1) {
                return "Tie";
            }

            var winner = new KeyValuePair<string, int>(String.Empty, 0);
            foreach(KeyValuePair<string, int> result in this.Results)
            {
                if (result.Value > winner.Value) {
                    winner = result;
                }
            }

            return winner.Key;
        }

        public int GetTeamTotal(string teamName) {
            return this.Results.GetValueOrDefault(teamName);
        }

        public override string ToString() {
            return String.Format("{0}|{1}", this.Combatants.Count, this.Winner);
        }
    }
}