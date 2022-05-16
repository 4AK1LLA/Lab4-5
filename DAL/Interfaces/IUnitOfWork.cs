using DAL.Entities;

namespace DAL.Interfaces
{
    public interface IUnitOfWork
    {
        IDataRepository<Exhibition> ExhibitionRepository { get; }

        IDataRepository<Excursion> ExcursionRepository { get; }

        Task<bool> ConfirmAsync();
    }
}
