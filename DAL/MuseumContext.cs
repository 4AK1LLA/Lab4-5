using Microsoft.EntityFrameworkCore;
using DAL.Entities;

namespace DAL
{
    public class MuseumContext : DbContext
    {
        public MuseumContext(DbContextOptions options)
            : base(options)
        {

        }
        public DbSet<Exhibition>? Exhibitions { get; set; }
        public DbSet<Excursion>? Excursions { get; set; }
    }
}
