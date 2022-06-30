using Microsoft.EntityFrameworkCore;
using Tarczynews.Models;

namespace Tarczynews.Data
{
    public class TarczynCapContext : DbContext
    {
        public TarczynCapContext(DbContextOptions<TarczynCapContext> options) : base(options)
        {

        }

        public DbSet<TarczynCap> tarczynCaps { get; set; }
    }
}
