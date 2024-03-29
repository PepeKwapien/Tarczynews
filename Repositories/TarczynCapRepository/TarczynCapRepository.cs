﻿using Tarczynews.Data;
using Tarczynews.Models;

namespace Tarczynews.Repositories
{
    public class TarczynCapRepository : ITarczynCapRepository
    {
        private readonly ApplicationDbContext _context;

        public TarczynCapRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public void Create(TarczynCap tarczynCap)
        {
            _context.TarczynCaps.Add(new TarczynCap(tarczynCap));
        }

        public void Delete(Guid id)
        {
            var storedCap = Read(id);

            if (storedCap != null)
            {
                _context.TarczynCaps.Remove(storedCap);
            }
        }

        public TarczynCap Read(Guid id)
        {
            return _context.TarczynCaps.FirstOrDefault(c => c.Id == id);
        }

        public IEnumerable<TarczynCap> ReadAll()
        {
            return _context.TarczynCaps.ToList();
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public void Update(TarczynCap tarczynCap)
        {
            if (tarczynCap != null)
            {
                var storedCap = Read(tarczynCap.Id);

                if (storedCap != null)
                {
                    storedCap.Copy(tarczynCap);
                }
            }
        }

        public IEnumerable<TarczynCap> ReadAllTarczynCapsSortedAscendingByNumber()
        {
            return ReadAll().OrderBy(cap => cap.Number);
        }

        public IEnumerable<TarczynCap> ReadAllTarczynCapsForUsernameSortedAscendingByNumber(string username)
        {
            return ReadAllTarczynCapsSortedAscendingByNumber().Where(cap => cap.Owner != null && cap.Owner.Email.Equals(username));
        }

        public TarczynCap ReadTarczynCapByNumber(int number)
        {
            return ReadAll().FirstOrDefault(x => x.Number == number);
        }

        public TarczynCap ReadTarczynCapByNumberAndOwnerUsername(int number, string email)
        {
            return ReadAll().FirstOrDefault(x => x.Owner != null && x.Owner.Email.Equals(email) && x.Number == number);
        }

        public TarczynCap ReadTarczynCapByIdAndOwnerUsername(Guid id, string email)
        {
            return ReadAll().FirstOrDefault(x => x.Owner != null && x.Owner.Email.Equals(email) && x.Id == id);
        }
    }
}
