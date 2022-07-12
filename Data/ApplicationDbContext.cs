using Microsoft.EntityFrameworkCore;
using Tarczynews.Models;

namespace Tarczynews.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<TarczynCap> TarczynCaps { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
    }
}
