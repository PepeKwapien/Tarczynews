using Microsoft.EntityFrameworkCore;
using Tarczynews.Models;

namespace Tarczynews.Data
{
    public class TarczynCapContext : DbContext
    {
        public DbSet<TarczynCap> TarczynCaps { get; set; }

        public TarczynCapContext(DbContextOptions<TarczynCapContext> options) : base(options)
        {
        }
    }
}
