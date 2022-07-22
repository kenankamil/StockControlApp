using Kenan.CodeBaseCodeChallange.DataAccess.Contexts;
using Kenan.CodeBaseCodeChallange.DataAccess.Interfaces;
using Kenan.CodeBaseCodeChallange.DataAccess.Repository;
using Kenan.CodeBaseCodeChallange.Entities;

namespace Kenan.CodeBaseCodeChallange.DataAccess.UnitOfWork
{
    public class UoW : IUoW
    {
        private readonly ProductContext _context;

        public UoW(ProductContext context)
        {
            _context = context;
        }

        public IRepository<T> GetRepository<T>() where T : BaseEntity
        {
            return new Repository<T>(_context);
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
