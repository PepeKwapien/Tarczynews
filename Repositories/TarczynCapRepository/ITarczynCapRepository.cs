using Tarczynews.Models;

namespace Tarczynews.Repositories
{
    public interface ITarczynCapRepository : IRepository<TarczynCap>
    {
        IEnumerable<TarczynCap> ReadAllTarczynCapsSortedAscendingByNumber();
        IEnumerable<TarczynCap> ReadAllTarczynCapsForEmailSortedAscendingByNumber(string email);
        TarczynCap ReadTarczynCapByNumber(int number);
    }
}
