using Rug.Domain.Match.MatchReferees;

namespace Rug.Domain.Referee.Calendar
{
    public class MatchCalendarRecord : CalendarRecord
    {
        public MatchCalendarRecord(Match.Match match, MatchRefereeType matchRefereeType)
            : base(match.Period)
        {
            Match = match;
            MatchRefereeType = matchRefereeType;
        }

        public Match.Match Match { get; }

        public MatchRefereeType MatchRefereeType { get; }
    }
}
