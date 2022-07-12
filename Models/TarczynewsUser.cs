using Microsoft.AspNetCore.Identity;

namespace Tarczynews.Models
{
    public class TarczynewsUser : IdentityUser
    {
        public ICollection<TarczynCap> TarczynCaps { get; set; }
    }
}
