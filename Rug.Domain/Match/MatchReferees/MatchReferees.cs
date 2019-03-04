using System.Collections.Generic;
using System.Linq;
using Rug.Domain.Match.MatchReferees.MatchLimits;

namespace Rug.Domain.Match.MatchReferees
{
    public class MatchReferees
    {
        private static readonly MatchRefereeTypeLimits MatchRefereeTypeLimits = new MatchRefereeTypeLimits();

        private IEnumerable<MatchReferee> _matchReferees;

        private ILookup<MatchRefereeType, Referee.Referee> _refereesByType;

        public MatchReferees(IEnumerable<MatchReferee> matchReferees)
        {
            _matchReferees = matchReferees;
            _refereesByType = _matchReferees.ToLookup(k => k.MatchRefereeType, v => v.Referee);
        }

        public Referee.Referee[] MainReferees => _refereesByType[MatchRefereeType.Main].ToArray();

        public Referee.Referee[] LineReferees => _refereesByType[MatchRefereeType.Line].ToArray();

        public Referee.Referee[] ScorerReferees => _refereesByType[MatchRefereeType.Scorer].ToArray();

        public Referee.Referee RefereeDelegate => _refereesByType[MatchRefereeType.Delegate].FirstOrDefault();

        public int GetRefereesCountByType(MatchRefereeType matchRefereeType)
        {
            return _refereesByType[matchRefereeType].Count();
        }

        public bool Contains(Referee.Referee referee)
        {
            return _refereesByType.Any(a => a.Contains(referee));
        }

        public bool CanAddReferee(MatchRefereeType type)
        {
            return MatchRefereeTypeLimits.IsInMaxRange(type, GetRefereesCountByType(type) + 1);
        }

        internal MatchReferees Add(MatchRefereeType matchRefereeType, Referee.Referee referee)
        {
            var matchReferees = new List<MatchReferee>(_matchReferees);
            matchReferees.Add(new MatchReferee(matchRefereeType, referee));

            return new MatchReferees(matchReferees);
        }
    }
}