using Kenan.CodeBaseCodeChallange.DataAccess.Contexts;
using Kenan.CodeBaseCodeChallange.DataAccess.Interfaces;
using Kenan.CodeBaseCodeChallange.Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Kenan.CodeBaseCodeChallange.DataAccess.Repository
{
    public class Repository<T> : IRepository<T> where T : BaseEntity
    {
        private readonly ProductContext _productContext;

        public Repository(ProductContext productContext)
        {
            _productContext = productContext;
        }

        public async Task CreateAsync(T entity)
        {
            await _productContext.Set<T>().AddAsync(entity);
        }

        public async Task<T> FindAsync(object id)
        {
            return await _productContext.Set<T>().FindAsync(id);
        }

        public async Task<List<T>> GetAllAsync()
        {
            return await _productContext.Set<T>().AsNoTracking().ToListAsync();
        }

        public async Task<T?> GetByFilterAsync(Expression<Func<T, bool>> filter, bool asNoTracking = false)
        {
            return !asNoTracking ? await _productContext.Set<T>().AsNoTracking().SingleOrDefaultAsync(filter) :
                 await _productContext.Set<T>().SingleOrDefaultAsync(filter);
        }
        public async Task<List<T>> GetListByFilterAsync(Expression<Func<T, bool>> filter, bool asNoTracking = false)
        {
            return !asNoTracking ? await _productContext.Set<T>().AsNoTracking().Where(filter).ToListAsync() :
                 await _productContext.Set<T>().Where(filter).ToListAsync();
        }

        public void Remove(T entity)
        {
            _productContext.Set<T>().Remove(entity);
        }

        public void Update(T entity)
        {
            _productContext.Set<T>().Update(entity);
        }
    }
}
