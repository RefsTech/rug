using Rug.Domain.Championship;
using Rug.Domain.Match.MatchReferees;
using Rug.Domain.Referee.Calendar;

namespace Rug.Domain.Referee
{
    public class Referee {

        public RefereeCategory RefereeCategory { get; set; }

        public RefereeCalendar RefereeCalendar { get; set; }

        public bool CanJudgeLeague(League.League league)
        {
            return league.CanBeJudgedByRefereeCategory(RefereeCategory);
        }

        public bool IsAllowedForNominationOnMatch(Match.Match match)
        {
            return RefereeCalendar.IsAvailableFor(match.Period);
        }

        public void NominatedOnMatchAs(Match.Match match, MatchRefereeType matchRefereeType, IPublisher publisher)
        {
            if (IsAllowedForNominationOnMatch(match))
            {
                RefereeCalendar.Add(new MatchCalendarRecord(match, matchRefereeType));
                publisher.SendEvent(new RefereeCalendarUpdated(this));
            }
        }
    }
}
