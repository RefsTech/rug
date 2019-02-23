using System;

namespace Rug.Domain.Championship
{
    public class Period
    {
        public Period(DateTime startDate, DateTime endDate)
        {
            // Validation

            StartDate = startDate;
            EndDate = endDate;
        }

        public DateTime StartDate { get; private set; }

        public DateTime EndDate { get; private set; }
    }
}