using Rug.Domain.Championship;
using Rug.Domain.Team;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Rug.Domain.Match
{
    public class MatchNominationException : Exception
    {
        public MatchNominationException(string message) : base(message)
        {
        }
    }

    public class Match
    {
        public League.League League { get; set; }

        public Team.Team HomeTeam { get; set; }

        public Team.Team AwayTeam { get; set; }

        public Period Period { get; set; }

        public Address HallAddress { get; set; }

        public MatchReferees MatchReferees { get; set; }

        public void Nominate(Referee.Referee referee, MatchRefereeType matchRefereeType)
        {
            if(HomeTeam == null || AwayTeam == null || Period == null || HallAddress == null)
            {
                throw new MatchNominationException("Match should have Home/Away Teams, StartDate and Hall");
            }

            if(MatchReferees.Contains(referee))
            {
                throw new MatchNominationException("Same Referee cant be on multiple positions");
            }

            if(!referee.CanJudgeLeague(League))
            {
                throw new MatchNominationException("Referee cant judge higher ranked league");
            }

            if(!referee.IsAllowedForNominationOnMatch(this))
            {
                throw new MatchNominationException("Referee is not free on that period of time");
            }

            if(!MatchReferees.CanAddReferee(matchRefereeType))
            {
                throw new MatchNominationException("Referees limit is reached");
            }

            MatchReferees = MatchReferees.Add(referee, matchRefereeType);

            // send notification about ref changes, send old set and new set, or just added ref
            // should affect ref calendar
        }
    }

    public class MatchReferees
    {
        private static readonly MatchRefereeTypeLimits MatchRefereeTypeLimits = new MatchRefereeTypeLimits();

        private Lookup<MatchRefereeType, Referee.Referee> _referees;

        public MatchReferees(Lookup<MatchRefereeType, Referee.Referee> referees)
        {
            _referees = referees;
        }

        public Referee.Referee[] MainReferees => _referees[MatchRefereeType.Main].ToArray();

        public Referee.Referee[] LineReferees => _referees[MatchRefereeType.Line].ToArray();

        public Referee.Referee[] ScorerReferees => _referees[MatchRefereeType.Scorer].ToArray();

        public Referee.Referee RefereeDelegate => _referees[MatchRefereeType.Delegate].FirstOrDefault();

        public int GetRefereesCountByType(MatchRefereeType matchRefereeType)
        {
            return _referees[matchRefereeType].Count();
        }

        public bool Contains(Referee.Referee referee)
        {
            return _referees.Any(a => a.Contains(referee));
        }

        public bool CanAddReferee(MatchRefereeType type)
        {
            return MatchRefereeTypeLimits.IsInMaxRange(type, GetRefereesCountByType(type) + 1);
        }

        internal MatchReferees Add(Referee.Referee referee, MatchRefereeType matchRefereeType)
        {
            // return new MatchReferees with added referee
            throw new NotImplementedException();

            
        }
    }

    public class MatchRefereeTypeLimits
    {
        private static readonly Dictionary<MatchRefereeType, ILimit> _refereesNumberLimits = new Dictionary<MatchRefereeType, ILimit>
        {
            { MatchRefereeType.Delegate, new RangeLimit(0, 1) },
            { MatchRefereeType.Main, new ValuesLimit(2) },
            { MatchRefereeType.Line, new ValuesLimit(2, 4) },
            { MatchRefereeType.Scorer, new ValuesLimit(1) },
        };

        public bool MatchFitsRefereesLimits(MatchReferees matchReferees)
        {
            return _refereesNumberLimits.All(
                a => IsNumberOfRefereesValid(
                    a.Key,
                    matchReferees.GetRefereesCountByType(a.Key)));
        }

        public bool IsInMaxRange(MatchRefereeType matchRefereeType, int refereesCount)
        {
            var limit = _refereesNumberLimits[matchRefereeType];
            return !limit.IsInMaxRange(refereesCount);
        }

        private bool IsNumberOfRefereesValid(MatchRefereeType matchRefereeType, int refereesCount)
        {
            var limit = _refereesNumberLimits[matchRefereeType];
            var isNumberOfRefereesCorrect = limit.IsValid(refereesCount);
            return isNumberOfRefereesCorrect;
        }
    }

    public interface ILimit
    {
        bool IsInMaxRange(int number);

        bool IsValid(int number);
    }

    public class ValuesLimit : ILimit
    {
        private int[] _values;

        public ValuesLimit(params int[] values)
        {
            _values = values.OrderBy(o => o).ToArray();
        }

        public bool IsInMaxRange(int number)
        {
            return number <= _values[_values.Length - 1];
        }

        public bool IsValid(int number)
        {
            return _values.Contains(number);
        }
    }

    public class RangeLimit : ILimit
    {
        public RangeLimit(int min, int max)
        {
            if (Min > Max)
            {
                throw new ArgumentOutOfRangeException("Range: Min is higher than Max");
            }
            Min = min;
            Max = max;
        }

        public int Min { get; }

        public int Max { get; }

        public bool IsInMaxRange(int number) {
            return number >= 0 && number <= Max;
        }

        public bool IsValid(int number)
        {
            return number >= Min && number <= Max;
        }
    }

    public enum MatchRefereeType
    {
        Delegate,
        Main,
        Line,
        Scorer
    }
}