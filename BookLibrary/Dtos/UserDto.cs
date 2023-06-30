using Microsoft.AspNetCore.Identity;

namespace BookLibrary.Dtos
{
    public class UserDto : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

    }
}
