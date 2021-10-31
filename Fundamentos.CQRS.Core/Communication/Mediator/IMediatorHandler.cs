using System.Threading.Tasks;
using Fundamentos.CQRS.Core.Messages;
using Fundamentos.CQRS.Core.Messages.CommonMessages.DomainEvents;
using Fundamentos.CQRS.Core.Messages.CommonMessages.Notifications;

namespace Fundamentos.CQRS.Core.Communication.Mediator
{
    public interface IMediatorHandler
    {
        Task<bool> EnviarComando<T>(T comando) where T : Command;
        Task PublicarEvento<T>(T evento) where T : Event;
        Task PublicarNotificacao<T>(T notificacao) where T : DomainNotification;
        Task PublicarDomainEvent<T>(T notificacao) where T : DomainEvent;
    }
}