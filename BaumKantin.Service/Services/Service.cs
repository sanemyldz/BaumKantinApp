using BaumKantin.Core.UnitOfWorks;
using BaumKantin.Repository;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace BaumKantin.Service.Services
{
    public class Service<T> : IService<T> where T : class
    {
        private readonly IGenericRepository<T> _genericRepository;
        private readonly IUnitOfWork _unitOfWork;

        public Service(IGenericRepository<T> genericRepository, IUnitOfWork unitOfWork)
        {
            _genericRepository = genericRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<T> AddAsync(T entity)
        {
            await _genericRepository.AddAsync(entity);
            await _unitOfWork.CommitAsync();
            return entity;
        }

        public async Task<List<T>> GetAllAsync()
        {
            return await _genericRepository.GetAll().ToListAsync();
        }

        public async Task<T> GetByIdAsync(int Id)
        {
            return await _genericRepository.GetByIdAsync(Id);
        }

        public IQueryable<T> Where(Expression<Func<T, bool>> expression)
        {
            return _genericRepository.Where(expression);
        }

        public async Task UpdateAsync(T entity)
        {
           _genericRepository.Update(entity);
            await _unitOfWork.CommitAsync();
        }

        public async Task RemoveAsync(T entity)
        {
            _genericRepository.Remove(entity);
            await _unitOfWork.CommitAsync();
        }
    }
}
