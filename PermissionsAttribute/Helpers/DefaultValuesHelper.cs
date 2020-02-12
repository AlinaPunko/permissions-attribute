using Microsoft.AspNetCore.Identity;
using PermissionsAttribute.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace PermissionsAttribute.Helpers
{
    public static class DefaultValuesHelper
    {
        public static async Task InitializeAsync(UserManager<IdentityUser> userManager)
        {
            const string adminEmail = "admin@gmail.com";
            const string password = "_Aa123456";
            if (await userManager.FindByNameAsync(adminEmail) == null)
            {
                IdentityUser admin = new IdentityUser { Email = adminEmail, UserName = adminEmail };
                IdentityResult result = await userManager.CreateAsync(admin, password);
                if (result.Succeeded)
                {
                    List<Claim> claims = new List<Claim>
                    {
                        new Claim("permission", Permissions.AddProfile.ToString()),
                        new Claim("permission", Permissions.DeleteProfile.ToString()),
                        new Claim("permission", Permissions.GetProfileById.ToString()),
                        new Claim("permission", Permissions.GetProfiles.ToString()),
                        new Claim("permission", Permissions.UpdateProfile.ToString()),
                    };
                    await userManager.AddClaimsAsync(admin, claims);
                }
            }
        }
    }
}
