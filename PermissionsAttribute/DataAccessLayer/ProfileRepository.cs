using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using PermissionsAttribute.Models;

namespace PermissionsAttribute.DataAccessLayer
{
    public class ProfileRepository : IRepository<Profile>
    {
        private DbSet<Profile> Profiles { get; }

        public ProfileRepository(DbContext context)
        {
            Profiles = context.Set<Profile>();
        }

        public void Add(Profile item)
        {
            Profiles.Add(item);
        }

        public IEnumerable<Profile> Get()
        {
            return Profiles;
        }

        public Profile GetById(int id)
        {
            return Profiles.FirstOrDefault(profile => profile.Id == id);
        }
        
        public void Remove(Profile item)
        {
            Profiles.Remove(item);
        }

        public void Update(Profile item)
        {
            Profile updatedItem = GetById(item.Id);

            if (updatedItem == null)
            {
                return;
            }

            if (!string.IsNullOrEmpty(item.Name))
            {
                updatedItem.Name = item.Name;
            }

            if (!string.IsNullOrEmpty(item.Email))
            {
                updatedItem.Email = item.Email;
            }
        }
    }
}
