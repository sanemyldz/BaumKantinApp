using System.Linq.Expressions;

namespace BaumKantin.Repository
{
    public interface IGenericRepository<T> where T:class 
    {
        IQueryable<T> GetAll();

        Task<T> GetByIdAsync(int Id);

        IQueryable<T> Where(Expression<Func<T, bool>> expression);

        Task AddAsync(T entity);
 
        void Remove(T entity);

        void Update(T entity);
    }
}
