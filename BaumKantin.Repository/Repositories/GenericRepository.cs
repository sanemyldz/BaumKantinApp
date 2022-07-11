using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;

namespace BaumKantin.Repository.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        protected readonly DataContext _dataContext;
        private readonly DbSet<T> _dbSet;

        public GenericRepository(DataContext DataContext)
        {
            _dataContext = DataContext;
            _dbSet = DataContext.Set<T>();

        }
        public IQueryable<T> GetAll()
        {
            return _dbSet.AsNoTracking().AsQueryable();
        }
        public async Task<T> GetByIdAsync(int Id)
        {
            return await _dbSet.FindAsync(Id);
        }
        public IQueryable<T> Where(Expression<Func<T, bool>> expression)
        {
            return _dbSet.Where(expression);
        }
        public async Task AddAsync(T entity)
        {
            await _dbSet.AddAsync(entity);
        }
        public void Remove(T entity)
        {
            _dbSet.Remove(entity);
        }
        public void Update(T entity)
        {
            _dbSet.Update(entity);
        }
    }
}
