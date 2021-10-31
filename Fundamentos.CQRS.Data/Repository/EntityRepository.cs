using Fundamentos.CQRS.Core.Data;
using Fundamentos.CQRS.Vendas.Domain;

namespace Fundamentos.CQRS.Vendas.Data.Repository
{
    public class EntityRepository : IEntityRepository
    {
        private readonly VendasContext _context;
        public EntityRepository(VendasContext context)
        {
            _context = context;
        }

        public IUnitOfWork UnitOfWork => _context;

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}