using System;
using System.Collections.Generic;
using System.Linq;

namespace AvengersSkillsUSA {
    public struct Bootstrap {
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

        public Team BootstrapThanos() {
            const string thanosTeamName = "Thanos";

            var thanos = new Avenger(thanosTeamName, 200, thanosTeamName);

            var thanosTeam = new Team(thanosTeamName);
            thanosTeam.Teammates.Add(thanos);

            return thanosTeam;
        }

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