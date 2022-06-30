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

        public TarczynCap Read(Guid id)
        {
            return TarczynCaps.FirstOrDefault(c => c.Id == id);
        }

        public IEnumerable<TarczynCap> ReadAllTarczynCaps()
        {
            return TarczynCaps.ToList();
        }

        public IEnumerable<TarczynCap> ReadAllTarczynCapsSortedAscendingByNumber()
        {
            return ReadAllTarczynCaps().OrderBy(cap => cap.Number);
        }

        public TarczynCap ReadTarczynCapByNumber(int number)
        {
            return TarczynCaps.FirstOrDefault(x => x.Number == number);
        }

        public void Create(TarczynCap tarczynCap)
        {
            TarczynCaps.Add(new TarczynCap(tarczynCap));
            SaveChanges();
        }

        public void Update(TarczynCap tarczynCap)
        {
            if (tarczynCap != null)
            {
                var storedCap = Read(tarczynCap.Id);

                if (storedCap != null)
                {
                    storedCap.Copy(tarczynCap);
                    SaveChanges();
                }
            }
        }

        public void Delete(Guid id)
        {
            var storedCap = Read(id);

            if (storedCap != null)
            {
                TarczynCaps.Remove(storedCap);
                SaveChanges();
            }
        }
    }
}
