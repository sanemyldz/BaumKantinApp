//BY UNIT.OF.WORK DATABASE IS AFFECTED IN ONE TRANSACTION 

namespace BaumKantin.Core.UnitOfWorks
{
    public interface IUnitOfWork
    {
        Task CommitAsync();
        void Commit();
    }
}
