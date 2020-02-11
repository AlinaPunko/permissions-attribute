using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using PermissionsAttribute.DataAccessLayer;
using PermissionsAttribute.Models;

namespace PermissionsAttribute.Controllers
{
    public class ProfilesController : Controller
    {
        private readonly ProfileRepository repository;
        public ProfilesController(ProfileRepository repository)
        {
            this.repository = repository;
        }

        [HttpGet]
        public IEnumerable<Profile> Get()
        {
            return repository.Get();
        }

        [HttpGet]
        [Route("[controller]/[action]/{id}")]
        public Profile GetById(int id)
        {
            return repository.GetById(id);
        }

        [HttpPost]
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
        public IActionResult Delete([FromBody] Profile profile)
        {
            repository.Remove(profile);
            return Ok();
        }
    }
}