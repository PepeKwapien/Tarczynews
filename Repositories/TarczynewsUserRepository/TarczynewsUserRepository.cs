using Tarczynews.Models;
using System.Web;
using Microsoft.AspNetCore.Identity;
using Tarczynews.Data;

namespace Tarczynews.Repositories
{
    public class TarczynewsUserRepository : ITarczynewsUserRepository
    {
        private readonly ApplicationDbContext _applicationDbContext;
        private readonly UserManager<TarczynewsUser> _userManager;
        private readonly IHttpContextAccessor _contextAccessor;

        public TarczynewsUserRepository(ApplicationDbContext context, UserManager<TarczynewsUser> userManager, IHttpContextAccessor httpContextAccessor)
        {
            this._applicationDbContext = context;
            this._userManager = userManager;
            this._contextAccessor = httpContextAccessor;
        }

        public void Create(TarczynewsUser model)
        {
            return;
        }

        public void Delete(Guid id)
        {
            return;
        }

        public TarczynewsUser Read(Guid id)
        {
            return _userManager.FindByIdAsync(id.ToString()).Result;
        }

        public IEnumerable<TarczynewsUser> ReadAll()
        {
            return new List<TarczynewsUser>();
        }

        public void Save()
        {
            this._applicationDbContext.SaveChanges();
        }

        public void Update(TarczynewsUser model)
        {
            _ = _userManager.UpdateAsync(model).Result;
        }

        public TarczynewsUser ReadCurrent()
        {
            return this._userManager.GetUserAsync(this._contextAccessor.HttpContext?.User).Result;
        }
    }
}
