using Rug.Domain.Championship;

namespace Rug.Domain.Referee
{
    public class RefereeCalendarUpdated : IEvent
    {
        public RefereeCalendarUpdated(Referee referee)
        {
            Referee = referee;
        }

        public Referee Referee { get; }
    }
}