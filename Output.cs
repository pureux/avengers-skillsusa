using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AvengersSkillsUSA {

    /// <summary>
    /// The output utility for reporting to the user
    /// </summary>
    public struct Output {

        /// <summary>
        /// The width to use for displaying tabular data
        /// </summary>
        /// <value></value>
        public int OutputWidth { get; private set; }

        /// <summary>
        /// The label used to indicate a tie
        /// </summary>
        /// <value></value>
        public string TieLabel { get; private set; }

        /// <summary>
        /// The initializer of an Output object
        /// </summary>
        /// <param name="tieLabel">The label used to indicate a tie</param>
        /// <param name="outputWidth">The width to use for displaying tabular data</param>
        public Output(string tieLabel, int outputWidth = 40) {
            this.OutputWidth = outputWidth;
            this.TieLabel = tieLabel;
        }

        /// <summary>
        /// Report the initial startup messaging
        /// </summary>
        public void ReportStartup() {
            Console.Clear();
            Console.WriteLine("Avengers SkillsUSA");
        }

        /// <summary>
        /// Report on each Avenger for whether they survived or perished after Thanos turned 50% to dust
        /// </summary>
        /// <param name="avengersSafety">A dictionary of Avengers and whether or not they perished</param>
        public void ReportAvengersSafety(Dictionary<string, bool> avengersSafety) {
            const int resultOutputWidth = 4;

            Console.WriteLine("Avengers");
            Console.WriteLine(new string('=', this.OutputWidth));

            foreach(KeyValuePair<string, bool> result in avengersSafety) {
                Console.WriteLine(String.Format(
                    "{0}{1}",
                    result.Key.PadRight(this.OutputWidth - resultOutputWidth),
                    result.Value ? "Dust" : "Safe"
                ));
            }

            Console.WriteLine();
        }

        /// <summary>
        /// Report how many battles each team won and the overall winner of the war
        /// </summary>
        /// <param name="battleWinners">A dictionary of winners and the number of battles they won</param>
        /// <param name="numberOfBattles">How many battles were fought</param>
        /// <param name="warWinner">Which team won the war</param>
        public void ReportCivilWarResults(Dictionary<string, int> battleWinners, int numberOfBattles, string warWinner) {
            Console.WriteLine("Battles Won");
            Console.WriteLine(new string('=', this.OutputWidth));

            int battlesWonOutputWidth = numberOfBattles.ToString().Length;
            foreach(KeyValuePair<string, int> winner in battleWinners) {
                Console.WriteLine(String.Format(
                    "{0}{1}",
                    winner.Key.PadRight(this.OutputWidth - battlesWonOutputWidth),
                    winner.Value.ToString().PadLeft(battlesWonOutputWidth)));
            }

            const string winnerLabel = "CIVIL WAR WINNER";

            Console.WriteLine(new string('-', this.OutputWidth));
            Console.WriteLine(String.Format(
                "{0}{1}\n",
                winnerLabel,
                warWinner.PadLeft(this.OutputWidth - winnerLabel.Length)));
        }

        /// <summary>
        /// Report the results of an individual battle, including the combatants
        /// </summary>
        /// <param name="battle">The battle object with its details and results</param>
        /// <param name="battleNumber">The sequence number of the battle</param>
        public void ReportBattleResults(Battle battle, int battleNumber = 1) {
            var builder = new StringBuilder();
            const int powerLevelOutputWidth = 5;
            const int combatantIndentWidth = 2;
            const string winnerLabel = "WINNER";

            Console.WriteLine("Battle {0}", battleNumber);
            Console.WriteLine(new string('=', this.OutputWidth));

            foreach(Team team in battle.Teams) {
                // Team Total
                builder.AppendFormat(
                    "{0}{1}\n",
                    team.Name,
                    battle.GetTeamTotal(team.Name).ToString().PadLeft(this.OutputWidth - team.Name.Length));

                // Team Combatants
                foreach(Avenger combatant in battle.Combatants.Where(c => c.Team == team.Name)) {
                    string indentedName = (new string(' ', combatantIndentWidth) + combatant.Name);
                    builder.AppendFormat(
                        "{0}{1}\n",
                        indentedName.PadRight(this.OutputWidth - powerLevelOutputWidth),
                        combatant.PowerLevel.ToString().PadLeft(powerLevelOutputWidth));
                }

                builder.AppendLine(new string('-', this.OutputWidth));
            }

            // Winner
            builder.AppendFormat(
                "{0}{1}\n",
                winnerLabel,
                battle.Winner.PadLeft(this.OutputWidth - winnerLabel.Length));

            Console.WriteLine(builder.ToString());
        }

        /// <summary>
        /// Report who won the battle/war (Thanos or the Avengers, or a tie)
        /// </summary>
        /// <param name="battle"></param>
        /// <param name="thanosTeamName">The team name used for Thanos, to see if he won</param>
        public void ReportInfinityWarResults(Battle battle, string thanosTeamName) {
            ReportBattleResults(battle);

            if (battle.Winner == thanosTeamName) {
                Console.WriteLine("Thanos defeated the Avengers and turned half of them to dust!");
            }
            else if (battle.Winner == this.TieLabel) {
                Console.WriteLine("The Avengers matched Thanos in power and tied.");
            }
            else {
                Console.WriteLine("The Avengers defeated Thanos and saved the world!");
            }

            Console.WriteLine();
        }
    }
}