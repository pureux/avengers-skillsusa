using System;
using System.Collections.Generic;
using System.Linq;

namespace AvengersSkillsUSA {

    /// <summary>
    /// The bootstrap utility to load and setup data initially
    /// </summary>
    public struct Bootstrap {

        /// <summary>
        /// Load the initial Avengers data
        /// </summary>
        /// <returns></returns>
        public List<Avenger> BootstrapAvengers() {
            const string teamStark = "Team Stark";
            const string teamCap = "Team Cap";
            var avengers = new List<Avenger>();

            avengers.Add(new Avenger("Black Widow", 10, teamStark));
            avengers.Add(new Avenger("War Machine", 20, teamStark));
            avengers.Add(new Avenger("Spider-Man", 30, teamStark));
            avengers.Add(new Avenger("Black Panther", 40, teamStark));
            avengers.Add(new Avenger("Iron Man", 50, teamStark));
            avengers.Add(new Avenger("Vision", 60, teamStark));

            avengers.Add(new Avenger("Hawkeye", 10, teamCap));
            avengers.Add(new Avenger("Falcon", 20, teamCap));
            avengers.Add(new Avenger("Ant-Man", 30, teamCap));
            avengers.Add(new Avenger("Winter Soldier", 40, teamCap));
            avengers.Add(new Avenger("Captain America", 50, teamCap));
            avengers.Add(new Avenger("Scarlet Witch", 60, teamCap));

            return avengers;
        }

        /// <summary>
        /// Load the initial teams data
        /// </summary>
        /// <param name="avengers">The list of Avengers to build the teams</param>
        /// <returns></returns>
        public List<Team> BootstrapTeams(List<Avenger> avengers) {
            var teams = new List<Team>();

            foreach (var avenger in avengers) {
                var team = teams.FirstOrDefault(t => t.Name == avenger.Team);
                if (team == null) {
                    team = new Team(avenger.Team);
                    teams.Add(team);
                }
                team.Teammates.Add(avenger);
            }

            return teams;
        }

        /// <summary>
        /// Load the initial data for Thanos
        /// </summary>
        /// <returns></returns>
        public Team BootstrapThanos() {
            const string thanosTeamName = "Thanos";

            var thanos = new Avenger(thanosTeamName, 200, thanosTeamName);

            var thanosTeam = new Team(thanosTeamName);
            thanosTeam.Teammates.Add(thanos);

            return thanosTeam;
        }

        /// <summary>
        /// Convert all of the Avengers to the same team
        /// </summary>
        /// <param name="avengers"></param>
        /// <returns></returns>
        public Team UniteTheAvengers(List<Avenger> avengers) {
            const string avengersTeamName = "Avengers";
            var avengersTeam = new Team(avengersTeamName);

            foreach(Avenger avenger in avengers) {
                avenger.Team = avengersTeamName;
            }

            avengersTeam.Teammates.AddRange(avengers);

            return avengersTeam;
        }
    }
}