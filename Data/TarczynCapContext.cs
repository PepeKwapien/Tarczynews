using Microsoft.EntityFrameworkCore;
using Tarczynews.Models;

namespace Tarczynews.Data
{
    public class TarczynCapContext : DbContext
    {
        public TarczynCapContext(DbContextOptions<TarczynCapContext> options) : base(options)
        {

        }

        public DbSet<TarczynCap> TarczynCaps { get; set; }

        public IEnumerable<TarczynCap> ReadAllTarczynCaps()
        {
            return TarczynCaps.ToList();
        }

        public TarczynCap ReadTarczynCapByNumber(int number)
        {
            return TarczynCaps.FirstOrDefault(x => x.Number == number);
        }
    }
}
