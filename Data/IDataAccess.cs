using Tarczynews.Models;

namespace Tarczynews.Data
{
    public interface IDataAccess
    {
        IEnumerable<TarczynCap> ReadAllTarczynCaps();
        void Save();
    }
}
