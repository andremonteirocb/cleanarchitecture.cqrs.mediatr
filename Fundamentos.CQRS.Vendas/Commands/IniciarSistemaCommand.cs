using System;
using FluentValidation;
using Fundamentos.CQRS.Core.Messages;

namespace Fundamentos.CQRS.Vendas.Application.Commands
{
    public class IniciarSistemaCommand : Command
    {
        public bool Iniciado { get; private set; }
        public DateTime? Data { get; private set; }

        public IniciarSistemaCommand(bool iniciado, DateTime? data)
        {
            Iniciado = iniciado;
            Data = data;
        }

        public override bool EhValido()
        {
            ValidationResult = new IniciarSistemaValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }

    public class IniciarSistemaValidation : AbstractValidator<IniciarSistemaCommand>
    {
        public IniciarSistemaValidation()
        {
            RuleFor(c => c.Data)
                .NotNull()
                .WithMessage("Data inválida");
        }
    }
}