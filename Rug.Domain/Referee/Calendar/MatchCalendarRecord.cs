namespace Rug.Domain.Referee
{
    public class MatchCalendarRecord : CalendarRecord
    {
        public MatchCalendarRecord(Match.Match match)
            : base(match.Period)
        {
            Match = match;
        }

        public Match.Match Match { get; set; }
    }
}
