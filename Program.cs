using System;
using System.Collections.Generic;
using System.Linq;

namespace AvengersSkillsUSA {
    class Program {
        static void Main(string[] args) {
            const string tieLabel = "Tie";
            var bootstrap = new Bootstrap();
            var input = new Input();
            var output = new Output(tieLabel);

            output.ReportStartup();

            List<Avenger> avengers = bootstrap.BootstrapAvengers();
            List<Team> teams = bootstrap.BootstrapTeams(avengers);

            // TODO: allow the end user to add Avengers

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

        static void FightCivilWar(List<Team> teams, Input input, Output output, string tieLabel) {
            int maxPossibleCombatantsPerTeam = GetMaxPossibleCombatantsFromTeams(teams);
            int numberOfCombatantsPerTeam = input.GetNumberOfSelectedCombatants(maxPossibleCombatantsPerTeam);
            int numberOfBattles = input.GetNumberOfBattles();
            var battleWinners = new Dictionary<string, int>();

            for (int battleNumber = 1; battleNumber <= numberOfBattles; battleNumber++) {
                var battle = new Battle(teams, numberOfCombatantsPerTeam, tieLabel);

                output.ReportBattleResults(battle, battleNumber);

                if (!battleWinners.ContainsKey(battle.Winner)) {
                    battleWinners.Add(battle.Winner, 0);
                }
                battleWinners[battle.Winner]++;
            }

            string warWinner = DetermineWarWinner(battleWinners, tieLabel);

            output.ReportCivilWarResults(battleWinners, numberOfBattles, warWinner);
        }

        static void FightInfinityWar(Team avengersTeam, Team thanosTeam, Output output, string tieLabel) {
            const int numberOfAvengersFightingThanos = 5;

            var teams = new List<Team>();
            teams.Add(avengersTeam);
            teams.Add(thanosTeam);

            var battle = new Battle(teams, numberOfAvengersFightingThanos, tieLabel);

            output.ReportInfinityWarResults(battle, thanosTeam.Name);

            if (battle.Winner == thanosTeam.Name) {
                Dictionary<string, bool> avengersSafety = avengersTeam.BalanceTheTeam();
                output.ReportAvengersSafety(avengersSafety);
            }
        }

        static string DetermineWarWinner(Dictionary<string, int> battleWinners, string tieLabel) {
            var winner = new KeyValuePair<string, int>(String.Empty, 0);
            foreach(KeyValuePair<string, int> result in battleWinners.Where(w => w.Key != tieLabel))
            {
                if (result.Value > winner.Value) {
                    winner = result;
                }
            }

            return String.IsNullOrEmpty(winner.Key) ? tieLabel : winner.Key;
        }

        static int GetMaxPossibleCombatantsFromTeams(List<Team> teams) {
            int max = 0;
            foreach (var team in teams) {
                if(team.NumberOfTeammates < max || max == 0) {
                    max = team.NumberOfTeammates;
                }
            }
            return max;
        }
    }
}
