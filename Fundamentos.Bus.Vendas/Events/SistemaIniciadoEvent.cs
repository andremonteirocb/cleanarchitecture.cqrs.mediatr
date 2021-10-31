using System;
using Fundamentos.CQRS.Core.Messages;

namespace Fundamentos.CQRS.Vendas.Application.Events
{
    public class SistemaIniciadoEvent : Event
    {
        public bool Iniciado { get; private set; }
        public DateTime? Data { get; private set; }

        public SistemaIniciadoEvent(bool iniciado, DateTime? data)
        {
            Iniciado = iniciado;
            Data = data;
        }
    }
}