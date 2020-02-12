using System.Collections.Generic;
using System.Linq;
using DataAccess.Core;
using DataAccess.Models;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.DataAccessLayer
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
