using Kenan.CodeBaseCodeChallange.DataAccess.Interfaces;
using Kenan.CodeBaseCodeChallange.Entities;

namespace Kenan.CodeBaseCodeChallange.DataAccess.UnitOfWork
{
    public interface IUoW
    {
        IRepository<T> GetRepository<T>() where T : BaseEntity;
        Task SaveChangesAsync();
    }
}
