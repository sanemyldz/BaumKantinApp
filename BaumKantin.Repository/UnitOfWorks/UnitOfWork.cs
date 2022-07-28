using BaumKantin.Core.UnitOfWorks;

namespace BaumKantin.Repository.UnitOfWorks
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DataContext _DataContext;
        public UnitOfWork(DataContext dataContext)
        {
            _DataContext = dataContext;
        }
        public void Commit()
        {
            _DataContext.SaveChanges();
        }
        public async Task CommitAsync()
        {
			await _DataContext.SaveChangesAsync();
        }
    }
}
