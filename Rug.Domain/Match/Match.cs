using Rug.Domain.Team;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Rug.Domain.Match
{
    public class Match {

        public Team.Team HomeTeam { get; set; }

        public Team.Team AwayTeam { get; set; }

        public DateTime StartDate { get; set; }

        public Address HallAddress { get; set; }

        public Referee.Referee RefereeDelegate { get; set; }

        public MatchReferees MatchReferees { get; set; }
    }

    public class MatchReferees
    {
        private Lookup<MatchRefereeType, Referee.Referee> _referees;

        public MatchReferees(Lookup<MatchRefereeType, Referee.Referee> referees)
        {
            _referees = referees;
        }

        public IEnumerable<Referee.Referee> MainReferees => _referees[MatchRefereeType.Main];

        public IEnumerable<Referee.Referee> LineReferees => _referees[MatchRefereeType.Line];

        public IEnumerable<Referee.Referee> ScoreReferees => _referees[MatchRefereeType.Score];
    }

    public enum MatchRefereeType
    {
        Main,
        Line,
        Score
    }
}