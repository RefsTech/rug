using Rug.Domain.Championship;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Rug.Domain.Services
{
    public class ChampionshipCreator
    {
        public static IReadOnlyList<Match.Match> Create(TeamShuffle shuffle)
        {
            var numberOfRounds = shuffle.Teams.Count - 1;
            var gamesPerRound = Math.Ceiling((double)numberOfRounds / 2);

            var teams = shuffle.Teams.Values.ToArray();
            var matches = new List<Match.Match>((int)(numberOfRounds * gamesPerRound));

            for (var round = 0; round < numberOfRounds; round++)
            {
                var i = 0;
                var y = teams.Length - 1;

                while (i < teams.Length / 2)
                {
                    if (teams[y] != 0 && teams[i] != 0)
                    {
                        matches.Add(new Match.Match(new Team.Team(teams[y]), new Team.Team(teams[i])));
                    }

                    i++;
                    y--;
                }

                var _fixed = teams[0];
                Array.ConstrainedCopy(teams, 1, teams, 0, teams.Length - 1);
                teams[teams.Length - 1] = teams[0];
                teams[0] = _fixed;
            }

            return matches;
        }
    }
}
