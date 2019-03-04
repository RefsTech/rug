using System.Threading.Tasks;
using MassTransit;
using Rug.Domain.Championship;
using Rug.Domain.Match.Events;

namespace Rug.Domain.Referee
{
    public class RefereeNominatedConsumer : IConsumer<RefereeNominated>
    {
        private readonly IPublisher _publisher;

        public RefereeNominatedConsumer(IPublisher publisher)
        {
            _publisher = publisher;
        }

        public Task Consume(ConsumeContext<RefereeNominated> context)
        {
            context.Message.Referee.NominatedOnMatchAs(
                context.Message.Match,
                context.Message.MatchRefereeType,
                _publisher);
            return Task.CompletedTask;
        }
    }
}