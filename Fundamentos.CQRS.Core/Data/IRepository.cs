using Fundamentos.CQRS.Core.DomainObjects;
using System;

namespace Fundamentos.CQRS.Core.Data
{
    public interface IRepository<T> : IDisposable where T : IAggregateRoot
    {
        IUnitOfWork UnitOfWork { get; }
    }
}