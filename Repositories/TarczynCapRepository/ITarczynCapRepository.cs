using Tarczynews.Models;

namespace Tarczynews.Repositories
{
    public interface ITarczynCapRepository : IRepository<TarczynCap>
    {
        IEnumerable<TarczynCap> ReadAllTarczynCapsSortedAscendingByNumber();
        IEnumerable<TarczynCap> ReadAllTarczynCapsForUsernameSortedAscendingByNumber(string username);
        TarczynCap ReadTarczynCapByNumber(int number);
        TarczynCap ReadTarczynCapByNumberAndOwnerUsername(int number, string email);
    }
}
