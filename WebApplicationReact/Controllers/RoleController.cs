using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplicationReact.Models;

namespace WebApplicationReact.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoleController : ControllerBase
    {
        static RoleController()
        {
        }
        [HttpGet]
        public IEnumerable<Role> Get()
        {
            return Globals.Roles;
        }

        [HttpPost]
        public IActionResult Post([FromForm]Role role)
        {
            role.Id = Globals.GetLastRoleId();

            Globals.Roles.Add(role);

            return Ok(role);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            Role role = Globals.Roles.FirstOrDefault(x => x.Id == id);

            if (role == null)
            {
                return NotFound();
            }

            Globals.Roles.Remove(role);

            return Ok(role);
        }
    }
}