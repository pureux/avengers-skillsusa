using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AvengersSkillsUSA {

    /// <summary>
    /// A battle object with teams, combatants, and results
    /// </summary>
    public class Battle {

        /// <summary>
        ///  Initialize a battle object
        /// </summary>
        /// <param name="teams">The teams participating in the battle</param>
        /// <param name="numberOfCombatantsPerTeam">How many combatants to select from each team</param>
        /// <param name="tieLabel">The label used to indicate a tie</param>
        public Battle(List<Team> teams, int numberOfCombatantsPerTeam, string tieLabel) {
            this.Results = new Dictionary<string, int>();
            this.Combatants = new List<Avenger>();
            this.Teams = teams;

            foreach (Team team in teams) {
                this.Combatants.AddRange(team.SelectCombatants(numberOfCombatantsPerTeam));

                int score = this.CalculateTotalPowerLevel(this.Combatants.Where(c => c.Team == team.Name).ToList());

                this.Results.Add(team.Name, score);
            }

            this.Winner = DetermineWinner(this.Results, tieLabel);
        }

        /// <summary>
        /// Which team was the winner (or a tie)
        /// </summary>
        /// <value></value>
        public string Winner { get; private set; }

        /// <summary>
        /// Which Avengers were chosen as combatants for the battle
        /// </summary>
        /// <value></value>
        public List<Avenger> Combatants { get; private set; }

        /// <summary>
        /// Which teams participated in the battle
        /// </summary>
        /// <value></value>
        public List<Team> Teams { get; private set; }

        /// <summary>
        /// A dictionary of team names and their total power level from their selected combatants
        /// </summary>
        /// <value></value>
        public Dictionary<string, int> Results { get; private set; }

        /// <summary>
        /// Calculate a team's total power level based on its combatants' power levels
        /// </summary>
        /// <param name="teamCombatants">The combatants chosen to fight for the team</param>
        /// <returns></returns>
        private int CalculateTotalPowerLevel(List<Avenger> teamCombatants) {
            int totalPowerLevel = 0;

            foreach (Avenger combatant in teamCombatants) {
                totalPowerLevel += combatant.PowerLevel;
            }

            return totalPowerLevel;
        }

        /// <summary>
        /// Calculate which team had the highest power level and thus is the winner, or if it was a tie
        /// </summary>
        /// <param name="results">A dictionary of team names and their total power level from their selected combatants</param>
        /// <param name="tieLabel">The label used to indicate a tie</param>
        /// <returns></returns>
        private string DetermineWinner(Dictionary<string, int> results, string tieLabel) {
            List<int> scores = new List<int>(results.Values);
            if (scores.Distinct().Count() <= 1) {
                return tieLabel;
            }

            KeyValuePair<string, int> winner = new KeyValuePair<string, int>(string.Empty, 0);
            foreach(KeyValuePair<string, int> result in this.Results)
            {
                if (result.Value > winner.Value) {
                    winner = result;
                }
            }

            return winner.Key;
        }

        /// <summary>
        /// Return the total power level for a particular team
        /// </summary>
        /// <param name="teamName">The team name to find the total power level for</param>
        /// <returns></returns>
        public int GetTeamTotal(string teamName) {
            return this.Results.GetValueOrDefault(teamName);
        }

        /// <summary>
        /// Override the ToString function to return a semi-unique identifier
        /// </summary>
        /// <returns></returns>
        public override string ToString() {
            return string.Format("{0}|{1}", this.Combatants.Count, this.Winner);
        }
    }
}