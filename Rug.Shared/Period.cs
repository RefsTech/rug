using System;
using System.Threading.Tasks;

namespace Rug.Domain.Championship
{
    public class Period : IEquatable<Period>
    {
        public Period(DateTime startDate, DateTime endDate)
        {
            if(startDate >= endDate)
            {
                throw new ArgumentOutOfRangeException("StartDate is bigger than EndDate");
            }

            StartDate = startDate;
            EndDate = endDate;
        }

        public DateTime StartDate { get; private set; }

        public DateTime EndDate { get; private set; }

        public bool Intersects(Period p)
        {
            return !(StartDate > p.EndDate || EndDate < p.StartDate);
        }

        public static int Comparison(Period p1, Period p2)
        {
            if (p1.Intersects(p2))
            {
                return 0;
            }

            return p1.StartDate > p2.StartDate ? 1 : -1;
        }

        public bool Equals(Period p)
        {
            return Intersects(p);
        }
    }

    public interface IPublisher
    {
        Task SetEvent<TEvent>() where TEvent : IEvent;
    }

    public interface IEvent
    {

    }

    public interface ICommand
    {

    }
}