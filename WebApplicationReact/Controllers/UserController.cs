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
    public class UserController : ControllerBase
    {
        static UserController()
        {
        }
        [HttpGet]
        public IEnumerable<User> Get()
        {
            return Globals.Users;
        }

        [HttpPost]
        public IActionResult Post([FromForm]User user)
        {
            user.Id = Globals.GetLastUserId();

            Globals.Users.Add(user);

            return Ok(user);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            User user = Globals.Users.FirstOrDefault(x => x.Id == id);

            if (user == null)
            {
                return NotFound();
            }

            Globals.Users.Remove(user);

            return Ok(user);
        }
    }
}