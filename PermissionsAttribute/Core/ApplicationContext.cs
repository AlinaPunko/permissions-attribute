using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PermissionsAttribute.Models;

namespace PermissionsAttribute.Core
{
    public sealed class ApplicationContext : IdentityDbContext<IdentityUser>
    {
        public DbSet<Profile> Profiles { get; set; }
        public ApplicationContext(DbContextOptions options) : base(options)
        {
            if (!Database.CanConnect())
            {
                Database.Migrate();
            }
        }
    }
}
