using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Fundamentos.CQRS.Core.Communication.Mediator;
using Fundamentos.CQRS.Core.Messages.CommonMessages.Notifications;

namespace Fundamentos.CQRS.Vendas.Application.Events
{
    public class PedidoEventHandler :
        INotificationHandler<SistemaIniciadoEvent>
    {

        private readonly IMediatorHandler _mediatorHandler;
        public PedidoEventHandler(IMediatorHandler mediatorHandler)
        {
            _mediatorHandler = mediatorHandler;
        }

        public async Task Handle(SistemaIniciadoEvent notification, CancellationToken cancellationToken)
        {
            await _mediatorHandler.PublicarNotificacao(new DomainNotification("", "Iniciado"));
        }
    }
}