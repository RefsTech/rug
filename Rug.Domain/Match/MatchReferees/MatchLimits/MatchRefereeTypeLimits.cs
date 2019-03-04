using System.Collections.Generic;
using System.Linq;

namespace Rug.Domain.Match.MatchReferees.MatchLimits
{
    public class MatchRefereeTypeLimits
    {
        private static readonly Dictionary<MatchRefereeType, ILimit> _refereesNumberLimits = new Dictionary<MatchRefereeType, ILimit>
        {
            { MatchRefereeType.Delegate, new RangeLimit(0, 1) },
            { MatchRefereeType.Main, new ValuesLimit(2) },
            { MatchRefereeType.Line, new ValuesLimit(2, 4) },
            { MatchRefereeType.Scorer, new ValuesLimit(1) },
        };

        ////public bool MatchFitsRefereesLimits(MatchReferees matchReferees)
        ////{
        ////    return _refereesNumberLimits.All(
        ////        a => IsNumberOfRefereesValid(
        ////            a.Key,
        ////            matchReferees.GetRefereesCountByType(a.Key)));
        ////}

        public bool IsInMaxRange(MatchRefereeType matchRefereeType, int refereesCount)
        {
            var limit = _refereesNumberLimits[matchRefereeType];
            return !limit.IsInMaxRange(refereesCount);
        }

        ////private bool IsNumberOfRefereesValid(MatchRefereeType matchRefereeType, int refereesCount)
        ////{
        ////    var limit = _refereesNumberLimits[matchRefereeType];
        ////    var isNumberOfRefereesCorrect = limit.IsValid(refereesCount);
        ////    return isNumberOfRefereesCorrect;
        ////}
    }
}