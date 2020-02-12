using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using PermissionsAttribute.Core;
using PermissionsAttribute.Models;

namespace PermissionsAttribute.DataAccessLayer
{
    public class ProfileRepository : GenericRepository<Profile>
    {
        public ProfileRepository(DbContext context) : base(context) { }

        public IReadOnlyList<Profile> GetAll()
        {
            return Get()
                .ToList();
        }
    }
}
