using Fundamentos.CQRS.Vendas.Application.Commands;
using Fundamentos.CQRS.Vendas.Application.Queries;
using Fundamentos.CQRS.Core.Communication.Mediator;
using Fundamentos.CQRS.Core.Messages.CommonMessages.Notifications;
using Fundamentos.CQRS.Vendas.Domain;
using Fundamentos.CQRS.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Diagnostics;
using System.Threading.Tasks;

namespace Fundamentos.CQRS.Controllers
{
    public class HomeController : Fundamentos.CQRS.Web.Controllers.ControllerBase
    {
        private readonly IEntityRepository _pedidoRepository;
        private readonly IMediatorHandler _mediatorHandler;
        public HomeController(INotificationHandler<DomainNotification> notifications,
                                  IEntityRepository pedidoRepository,
                                  IMediatorHandler mediatorHandler) 
            : base(notifications, mediatorHandler)
        {
            _pedidoRepository = pedidoRepository;
            _mediatorHandler = mediatorHandler;
        }

        public async Task<IActionResult> Index()
        {
            await _mediatorHandler.EnviarComando(new IniciarSistemaCommand(true, DateTime.Now));

            if (OperacaoValida())
                return RedirectToAction("Privacy");

            NotificarErro("", "Notificação manual!");
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
