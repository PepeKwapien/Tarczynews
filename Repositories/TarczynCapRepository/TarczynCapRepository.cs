using Tarczynews.Data;
using Tarczynews.Models;

namespace Tarczynews.Repositories
{
    public class TarczynCapRepository : ITarczynCapRepository
    {
        private readonly IDataAccess _dataAccess;

        public TarczynCapRepository(IDataAccess dataAccess)
        {
            _dataAccess = dataAccess;
        }

        public void Create(TarczynCap tarczynCap)
        {
            _dataAccess.ReadAllTarczynCaps().ToList().Add(new TarczynCap(tarczynCap));
            Save();
        }

        public void Delete(Guid id)
        {
            var storedCap = Read(id);

            if (storedCap != null)
            {
                ReadAll().ToList().Remove(storedCap);
                Save();
            }
        }

        public TarczynCap Read(Guid id)
        {
            return ReadAll().FirstOrDefault(c => c.Id == id);
        }

        public IEnumerable<TarczynCap> ReadAll()
        {
            throw new NotImplementedException();
        }

        public void Save()
        {
            _dataAccess.Save();
        }

        public void Update(TarczynCap tarczynCap)
        {
            if (tarczynCap != null)
            {
                var storedCap = Read(tarczynCap.Id);

                if (storedCap != null)
                {
                    storedCap.Copy(tarczynCap);
                    Save();
                }
            }
        }

        public IEnumerable<TarczynCap> ReadAllTarczynCapsSortedAscendingByNumber()
        {
            return ReadAll().OrderBy(cap => cap.Number);
        }

        public TarczynCap ReadTarczynCapByNumber(int number)
        {
            return ReadAll().FirstOrDefault(x => x.Number == number);
        }
    }
}
