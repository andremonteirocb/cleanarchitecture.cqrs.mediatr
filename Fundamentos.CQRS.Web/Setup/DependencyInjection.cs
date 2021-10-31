using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Fundamentos.CQRS.Core.Communication.Mediator;
using Fundamentos.CQRS.Core.Messages.CommonMessages.Notifications;
using Fundamentos.CQRS.Vendas.Application.Commands;
using Fundamentos.CQRS.Vendas.Application.Events;
using Fundamentos.CQRS.Vendas.Data;
using Fundamentos.CQRS.Vendas.Data.Repository;
using Fundamentos.CQRS.Vendas.Domain;

namespace Fundamentos.CQRS.Web.Setup
{
    public static class DependencyInjection
    {
        public static void RegisterServices(this IServiceCollection services)
        {
            // Mediator
            services.AddScoped<IMediatorHandler, MediatorHandler>();

            // Notifications
            services.AddScoped<INotificationHandler<DomainNotification>, DomainNotificationHandler>();

            // Vendas
            services.AddScoped<IEntityRepository, EntityRepository>();
            services.AddScoped<VendasContext>();
            services.AddScoped<IRequestHandler<IniciarSistemaCommand, bool>, PedidoCommandHandler>();
            services.AddScoped<INotificationHandler<SistemaIniciadoEvent>, PedidoEventHandler>();
        }
    }
}