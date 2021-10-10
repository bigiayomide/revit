using System.Threading.Tasks;

namespace Revix.Data.Interfaces
{
    public interface IUnitOfWork
    {
        Task<int> CommitAsync();
    }
}