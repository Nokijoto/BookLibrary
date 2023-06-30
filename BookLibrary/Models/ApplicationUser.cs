using BookLibrary.Models.PageModels;
using Microsoft.AspNetCore.Identity;

namespace BookLibrary.Models
{
    public class ApplicationUser : IdentityUser
    {
        public ICollection<UserShelfs> UserShelfs { get; set; }
    }
}