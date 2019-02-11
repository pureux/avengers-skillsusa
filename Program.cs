using System;
using System.Collections.Generic;
using System.Linq;

namespace AvengersSkillsUSA {

    /// <summary>
    /// The main class responsible for running the application
    /// </summary>
    class Program {

        /// <summary>
        /// The main execution of the console application
        /// </summary>
        /// <param name="args">Any initial arguments passed into the application on startup</param>
        static void Main(string[] args) {
            const string tieLabel = "Tie";
            Bootstrap bootstrap = new Bootstrap();
            Input input = new Input();
            Output output = new Output(tieLabel);

            output.ReportStartup();

            List<Avenger> avengers = bootstrap.BootstrapAvengers();
            AddCustomAvengers(ref avengers, input);

            List<Team> teams = bootstrap.BootstrapTeams(avengers);

            Input.WarMode warMode = input.GetWarMode();

            if (warMode == Input.WarMode.CivilWar) {
                FightCivilWar(teams, input, output, tieLabel);
            }
            else {
                Team thanosTeam = bootstrap.BootstrapThanos();
                Team avengersTeam = bootstrap.UniteTheAvengers(avengers);
                FightInfinityWar(avengersTeam, thanosTeam, output, tieLabel);
            }
        }

        /// <summary>
        /// Allow the user to add their own Avenger, and possibly create a new team
        /// </summary>
        /// <param name="avengers"></param>
        /// <param name="input"></param>
        static void AddCustomAvengers(ref List<Avenger> avengers, Input input) {
            bool addAvenger = input.AskAddAvenger();
            while (addAvenger) {
                List<string> existingAvengerNames = avengers.Select(a => a.Name).OrderBy(n => n).ToList();
                string name = input.AskAvengerName(existingAvengerNames);
                int powerLevel = input.AskAvengerPowerLevel();
                string team = input.AskAvengerTeam();

                Avenger avenger = new Avenger(name, powerLevel, team);
                avengers.Add(avenger);

                addAvenger = input.AskAddAvenger();
            }
        }

        /// <summary>
        /// Process through fighting Civil War mode
        /// </summary>
        /// <param name="teams"></param>
        /// <param name="input">The input utility for gathering input from the user</param>
        /// <param name="output">The output utility for reporting to the user</param>
        /// <param name="tieLabel">The label used to indicate a tie</param>
        static void FightCivilWar(List<Team> teams, Input input, Output output, string tieLabel) {
            int maxPossibleCombatantsPerTeam = GetMaxPossibleCombatantsFromTeams(teams);
            int numberOfCombatantsPerTeam = input.GetNumberOfSelectedCombatants(maxPossibleCombatantsPerTeam);
            int numberOfBattles = input.GetNumberOfBattles();
            Dictionary<string, int> battleWinners = new Dictionary<string, int>();

            for (int battleNumber = 1; battleNumber <= numberOfBattles; battleNumber++) {
                Battle battle = new Battle(teams, numberOfCombatantsPerTeam, tieLabel);

                output.ReportBattleResults(battle, battleNumber);

                if (!battleWinners.ContainsKey(battle.Winner)) {
                    battleWinners.Add(battle.Winner, 0);
                }
                battleWinners[battle.Winner]++;
            }

            Dictionary<string, int> nonTieBattleWinners = RemoveTiesFromBattleWinners(battleWinners, tieLabel);
            string warWinner = DetermineWarWinner(nonTieBattleWinners, tieLabel);

            output.ReportCivilWarResults(battleWinners, numberOfBattles, warWinner);
        }

        /// <summary>
        /// Remove the battles that were tied fro the winners list; even if there were more ties than there were wins by a certain team,
        /// that doesn't mean the war result was a tie
        /// </summary>
        /// <param name="battleWinners">A dictionary of winners and the number of battles they won</param>
        /// <param name="tieLabel">The label used to indicate a tie</param>
        /// <returns></returns>
        static Dictionary<string, int> RemoveTiesFromBattleWinners(Dictionary<string, int> battleWinners, string tieLabel) {
            Dictionary<string, int> nonTieBattleWinners = new Dictionary<string, int>();
            foreach (KeyValuePair<string, int> battleWinner in battleWinners) {
                if (battleWinner.Key != tieLabel) {
                    nonTieBattleWinners.Add(battleWinner.Key, battleWinner.Value);
                }
            }
            return nonTieBattleWinners;
        }

        /// <summary>
        /// Process through fighting the Infinity War mode
        /// </summary>
        /// <param name="avengersTeam">The team of all Avengers</param>
        /// <param name="thanosTeam">The team of only Thanos</param>
        /// <param name="output">The output utility for reporting to the user</param>
        /// <param name="tieLabel">The label used to indicate a tie</param>
        static void FightInfinityWar(Team avengersTeam, Team thanosTeam, Output output, string tieLabel) {
            const int numberOfAvengersFightingThanos = 5;

            List<Team> teams = new List<Team>();
            teams.Add(avengersTeam);
            teams.Add(thanosTeam);

            Battle battle = new Battle(teams, numberOfAvengersFightingThanos, tieLabel);

            output.ReportInfinityWarResults(battle, thanosTeam.Name);

            if (battle.Winner == thanosTeam.Name) {
                Dictionary<string, bool> avengersSafety = avengersTeam.BalanceTheTeam();
                output.ReportAvengersSafety(avengersSafety);
            }
        }

        /// <summary>
        /// Determine which team won the most battles and is ultimately the winner of the war
        /// </summary>
        /// <param name="battleWinners">A dictionary of winners and the number of battles they won</param>
        /// <param name="tieLabel">The label used to indicate a tie</param>
        /// <returns></returns>
        static string DetermineWarWinner(Dictionary<string, int> battleWinners, string tieLabel) {
            List<int> scores = new List<int>(battleWinners.Values);
            if (scores.Distinct().Count() <= 1) {
                return tieLabel;
            }

            KeyValuePair<string, int> winner = new KeyValuePair<string, int>(string.Empty, 0);
            foreach(KeyValuePair<string, int> result in battleWinners)
            {
                if (result.Value > winner.Value) {
                    winner = result;
                }
            }

            return string.IsNullOrEmpty(winner.Key) ? tieLabel : winner.Key;
        }

        /// <summary>
        /// Determine the maximum number of combatants that can be entered, looking at the number of Avengers in each team
        /// </summary>
        /// <param name="teams">The list of all teams, which includes their Avengers</param>
        /// <returns></returns>
        static int GetMaxPossibleCombatantsFromTeams(List<Team> teams) {
            int max = 0;
            foreach (Team team in teams) {
                if(team.NumberOfTeammates >= max || max == 0) {
                    max = team.NumberOfTeammates;
                }
            }
            return max;
        }
    }
}
