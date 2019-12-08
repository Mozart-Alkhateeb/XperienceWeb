using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Xperience.Data.Entities.Users;
using Xperience.Data;
using Microsoft.AspNetCore.Identity;

namespace Xperience.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly ApplicationDbContext context;

        public UserController(ApplicationDbContext context)
        {
            this.context = context;
        }

        [HttpGet]
        public ActionResult<IEnumerable<String>> Get()
        {
            return new String[] { "Hello, World!", "API Shit" };
        }

        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "Hello, World!";
        }


        [HttpPost]
        public ActionResult Post([FromBody] BaseUser newUser)
        {
            context.Users.Add(newUser);
            context.SaveChanges();
            return Ok();
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {

        }

        [HttpPut("{id}")]
        public void Put(int id, [FromBody]String newVal)
        {
        }
    }
}