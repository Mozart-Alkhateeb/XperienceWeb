using System.Threading.Tasks;
using System;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Xperience.Data.Entities.Users;
using Xperience.Data;
using Xperience.APIModels;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Xperience.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly UserManager<BaseUser> _userManager;
        private readonly ApplicationDbContext _dbContext;

        public UsersController(
            UserManager<BaseUser> userManager,
            ApplicationDbContext dbContext)
        {
            _userManager = userManager;
            _dbContext = dbContext;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<string>> GetAsync(String id)
        {

            var data = await _userManager.FindByIdAsync(id);
            if (data == null)
                return BadRequest();
            return Ok(data);
        }

        [HttpPost]
        public async Task<ActionResult> PostAsync(ManageUserModel newUser)
        {
            try
            {
                var user = new ApplicationUser
                {
                    UserName = newUser.UserName,
                    Email = newUser.Email,
                    DateOfBirth = newUser.DateOfBirth,
                    Gender = newUser.Gender
                };

                var result = await _userManager.CreateAsync(user, newUser.Password);

                _dbContext.SaveChanges();
                return Ok();
            }
            catch (Exception ex)
            {
                throw ex;
            }
           
        }
        [HttpGet]
        public async Task<IActionResult> OnGetAsync()
        {
            var data = await _userManager.GetUserAsync(HttpContext.User);
            if (data == null) return NotFound();
            return Ok(data);
        }
    }
}
