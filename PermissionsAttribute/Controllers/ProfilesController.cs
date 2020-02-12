using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using PermissionsAttribute.Attributes;
using PermissionsAttribute.Constants;
using PermissionsAttribute.Core;
using PermissionsAttribute.DataAccessLayer;
using PermissionsAttribute.Models;

namespace PermissionsAttribute.Controllers
{
    public class ProfilesController : Controller
    {
        private readonly ProfileRepository repository;
        public ProfilesController(ApplicationContext context)
        {
            repository = new ProfileRepository(context);
        }

        [HttpGet]
        [HasPermission(Permissions.GetProfiles)]
        public IEnumerable<Profile> Get()
        {
            return repository.GetAll();
        }

        [HttpGet]
        [Route("[controller]/[action]/{id}")]
        [HasPermission(Permissions.GetProfileById)]
        public Profile GetById(int id)
        {
            return repository.GetById(id);
        }

        [HttpPost]
        [HasPermission(Permissions.AddProfile)]
        public IActionResult Create([FromBody] Profile profile)
        {
            if (profile == null)
            {
                return BadRequest();
            }

            repository.Add(profile);
            return Ok();
        }

        [HttpPatch]
        [HasPermission(Permissions.UpdateProfile)]
        public IActionResult Update([FromBody] Profile profile)
        {
            if (profile == null)
            {
                return BadRequest();
            }

            repository.Update(profile);
            return Ok();
        }

        [HttpDelete]
        [HasPermission(Permissions.DeleteProfile)]
        public IActionResult Delete([FromBody] Profile profile)
        {
            repository.Remove(profile);
            return Ok();
        }
    }
}