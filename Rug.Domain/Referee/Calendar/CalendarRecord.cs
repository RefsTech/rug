using System;
using Rug.Domain.Championship;

namespace Rug.Domain.Referee
{
    public abstract class CalendarRecord
    {
        public CalendarRecord(Period period)
        {
            Period = period ?? throw new ArgumentNullException(nameof(period));
        }

        public Period Period { get; }
    }
}
