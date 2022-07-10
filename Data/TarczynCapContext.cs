using Microsoft.EntityFrameworkCore;
using Tarczynews.Models;

namespace Tarczynews.Data
{
    public class TarczynCapContext : DbContext, IDataAccess
    {
        public DbSet<TarczynCap> TarczynCaps { get; set; }

        public TarczynCapContext(DbContextOptions<TarczynCapContext> options) : base(options)
        {
        }

        public IEnumerable<TarczynCap> ReadAllTarczynCaps()
        {
            return TarczynCaps.ToList();
        }

        public void Save()
        {
            SaveChanges();
        }
    }
}
