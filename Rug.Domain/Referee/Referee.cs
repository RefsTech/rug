using Rug.Domain.Team;

namespace Rug.Domain.Referee
{
    public class Referee {

        public Address Address { get; set; }

        public RefereeCategory RefereeCategory { get; set; }

        public RefereeCalendar RefereeCalendar { get; set; }

        internal bool CanJudgeLeague(League.League league)
        {
            return league.CanBeJudgedByRefereeCategory(RefereeCategory);
        }

        internal bool IsAllowedForNominationOnMatch(Match.Match match)
        {
            return RefereeCalendar.IsAvailableFor(match.Period);
        }
    }
}
