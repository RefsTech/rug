using System;
using System.Collections.Generic;
using System.Linq;
using Rug.Domain.Championship;

namespace Rug.Domain.Referee.Calendar
{
    public class RefereeCalendar
    {
        private static readonly PeriodsComparer PeriodsComparer = new PeriodsComparer();

        public SortedSet<Period> Periods { get; }

        public IEnumerable<CalendarRecord> CalendarRecords { get; }

        public RefereeCalendar(IEnumerable<CalendarRecord> calendarRecords)
        {
            Periods = new SortedSet<Period>(calendarRecords.Select(s => s.Period), PeriodsComparer);

            CalendarRecords = calendarRecords;
        }

        public bool IsAvailableFor(Period period)
        {
            return !Periods.Contains(period);
        }

        public RefereeCalendar Add(CalendarRecord calendarRecord)
        {
            if(IsAvailableFor(calendarRecord.Period))
            {
                throw new ApplicationException($"{nameof(CalendarRecord)} overlaps");
            }

            return new RefereeCalendar(CalendarRecords.Union(new[] { calendarRecord }));
        }
    }
}
