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
    public class PhoneController : ControllerBase
    {
        static readonly List<Phone> data;
        static PhoneController()
        {
            data = new List<Phone>
            {
                new Phone { Id = Guid.NewGuid().ToString(), Name="iPhone 7", Price=52000 },
                new Phone { Id = Guid.NewGuid().ToString(), Name="Samsung Galaxy S7", Price=42000 },
            };
        }
        [HttpGet]
        public IEnumerable<Phone> Get()
        {
            return data;
        }

        [HttpPost]
        public IActionResult Post([FromForm]Phone phone)
        {
            phone.Id = Guid.NewGuid().ToString();
            data.Add(phone);
            return Ok(phone);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(string id)
        {
            Phone phone = data.FirstOrDefault(x => x.Id == id);
            if (phone == null)
            {
                return NotFound();
            }
            data.Remove(phone);
            return Ok(phone);
        }
    }
}