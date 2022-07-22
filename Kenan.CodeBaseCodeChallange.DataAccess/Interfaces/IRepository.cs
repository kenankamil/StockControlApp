using Kenan.CodeBaseCodeChallange.Entities;
using System.Linq.Expressions;

namespace Kenan.CodeBaseCodeChallange.DataAccess.Interfaces
{
    public interface IRepository<T> where T : BaseEntity
    {
        Task<List<T>> GetAllAsync();
        Task<T> FindAsync(object id);
        Task<T> GetByFilterAsync(Expression<Func<T, bool>> filter, bool asNoTracking = false);
        Task<List<T>> GetListByFilterAsync(Expression<Func<T, bool>> filter, bool asNoTracking = false);
        void Remove(T entity);
        Task CreateAsync(T entity);
        void Update(T entity);
    }
}
