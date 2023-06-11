using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Tarczynews.Models;

namespace Tarczynews.Data
{
    public class ApplicationDbContext : IdentityDbContext<TarczynewsUser>
    {
        public DbSet<TarczynCap> TarczynCaps { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
    }
}
