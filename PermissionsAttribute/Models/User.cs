using Microsoft.AspNetCore.Identity;

namespace PermissionsAttribute.Models
{
    public class User : IdentityUser
    { 
        public int Year { get; set; }
    }
}
