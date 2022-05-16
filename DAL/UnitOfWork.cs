using DAL.Entities;
using DAL.Interfaces;

namespace DAL
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly MuseumContext _context;

        public UnitOfWork(MuseumContext context)
        {
            _context = context;

            _context.Database.EnsureCreated();

            ExhibitionRepository = new DataRepository<Exhibition>(context);
            ExcursionRepository = new DataRepository<Excursion>(context);
        }

        public IDataRepository<Exhibition> ExhibitionRepository { get; private set; }

        public IDataRepository<Excursion> ExcursionRepository { get; private set; }

        public async Task<bool> ConfirmAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }
    }
}
