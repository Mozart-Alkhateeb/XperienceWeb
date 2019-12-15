using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Xperience.APIModels;
using Xperience.Data;
using Xperience.Data.Entities.Users;

namespace Xperience.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly UserManager<BaseUser> _userManager;
        private readonly ApplicationDbContext _dbContext;

        public UsersController(UserManager<BaseUser> userManager, ApplicationDbContext dbContext)
        {
            _userManager = userManager;
            _dbContext = dbContext;
        }

        [HttpPost] // This is the register method

        //h
        public async Task<IActionResult> Post(ManageUserModel value)
        {
            try
            {
                // First we create the base user using the user manager class
                var baseUser = new BaseUser { UserName = value.UserName, Email = value.Email };
                var result = await _userManager.CreateAsync(baseUser, value.Password);

                // Then if the user was created successfully we add the compliment of the user which is saved in another table
                if (result.Succeeded)
                {
                    try
                    {
                        // This way of setting the properties of an object is not a good practice, (Check out something called Automapper, if you want)
                        var user = new ApplicationUser()
                        {
                            Id = baseUser.Id,
                            LocationId = value.LocationId,
                            Name = value.Name,
                            DateOfBirth = value.DateOfBirth,
                            Biography = value.Biography,
                            Info = value.Info,
                            Gender = value.Gender,
                            ReligionId = value.ReligionId,
                        };

                        _dbContext.ApplicationUsers.Add(user);
                        await _dbContext.SaveChangesAsync();
                    }
                    catch (Exception ex)
                    {

                        await _userManager.DeleteAsync(baseUser);
                    }
                }

                return Ok(); // This Could also return Created()
            }
            catch (Exception ex)
            {
                // Here we should do some logging and tell the user why there was an error
                return BadRequest("Some error message");
            }
        }
    }
}