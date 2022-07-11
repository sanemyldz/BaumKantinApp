using System.Linq.Expressions;

namespace BaumKantin.Service
{
    public interface IService<T> where T:class
    {
        Task<List<T>> GetAllAsync();

        Task<T> GetByIdAsync(int Id);

        IQueryable<T> Where(Expression<Func<T, bool>> expression);

        Task<T> AddAsync(T entity);

        Task RemoveAsync(T entity);

        Task UpdateAsync(T entity);
    }
}
