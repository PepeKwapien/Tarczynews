using System.Data.Entity;
using Tarczynews.Models;

namespace Tarczynews.Data
{
    public class TarczynCapContext : DbContext
    {
        public TarczynCapContext() : base("TarczynCapContext")
        {

        }

        public DbSet<TarczynCap> tarczynCaps { get; set; }
    }
}
