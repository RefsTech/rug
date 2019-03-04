using System.Collections.Generic;
using Rug.Domain.Championship;

namespace Rug.Domain.Referee.Calendar
{
    public class PeriodsComparer : IComparer<Period>
    {
        public int Compare(Period x, Period y)
        {
            if(x.Intersects(y))
            {
                return 0;
            }

            return x.StartDate > y.StartDate ? 1 : -1;
        }
    }
}
