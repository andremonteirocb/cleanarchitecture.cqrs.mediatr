using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Fundamentos.CQRS.Vendas.Application.Events;
using Fundamentos.CQRS.Vendas.Domain;
using Fundamentos.CQRS.Core.Communication.Mediator;
using Fundamentos.CQRS.Core.Messages;
using Fundamentos.CQRS.Core.Messages.CommonMessages.Notifications;
using Fundamentos.CQRS.Core.Extensions;

namespace Fundamentos.CQRS.Vendas.Application.Commands
{
    public class PedidoCommandHandler :
        IRequestHandler<IniciarSistemaCommand, bool>
    {
        private readonly IEntityRepository _entityRepository;
        private readonly IMediatorHandler _mediatorHandler;
        public PedidoCommandHandler(IEntityRepository entityRepository, 
                                    IMediatorHandler mediatorHandler)
        {
            _entityRepository = entityRepository;
            _mediatorHandler = mediatorHandler;
        }

        public async Task<bool> Handle(IniciarSistemaCommand message, CancellationToken cancellationToken)
        {
            if (!ValidarComando(message)) return false;

            await _mediatorHandler.PublicarEvento(new SistemaIniciadoEvent(message.Iniciado, message.Data));

            return true;
        }
        private bool ValidarComando(Command message)
        {
            if (message.EhValido()) return true;

            foreach (var error in message.ValidationResult.Errors)
            {
                _mediatorHandler.PublicarNotificacao(new DomainNotification(message.MessageType, error.ErrorMessage));
            }

            return false;
        }

    }
}