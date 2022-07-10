using Tarczynews.Models;

namespace Tarczynews.Repositories
{
    public interface ITarczynCapRepository : IRepository<TarczynCap>
    {
        IEnumerable<TarczynCap> ReadAllTarczynCapsSortedAscendingByNumber();
        TarczynCap ReadTarczynCapByNumber(int number);
    }
}
