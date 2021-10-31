using System.Threading.Tasks;

namespace Fundamentos.CQRS.Core.Data
{
    public interface IUnitOfWork
    {
        Task<bool> Commit();
    }
}