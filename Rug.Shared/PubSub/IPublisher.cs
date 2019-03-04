using System.Threading.Tasks;

namespace Rug.Domain.Championship
{
    public interface IPublisher
    {
        Task SendEvent<TEvent>(TEvent e) where TEvent : IEvent;

        Task SendCommand<TCommand>(TCommand command) where TCommand : ICommand;
    }
}