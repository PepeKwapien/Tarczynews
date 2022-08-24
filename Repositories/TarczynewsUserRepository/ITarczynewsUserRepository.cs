using Tarczynews.Models;

namespace Tarczynews.Repositories
{
    public interface ITarczynewsUserRepository : IRepository<TarczynewsUser>
    {
        TarczynewsUser ReadCurrent();
    }
}
