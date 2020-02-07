using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Xperience.Data.Entities.Users;
using Xperience.Data;
using Microsoft.AspNetCore.Hosting;
using System.Collections.Generic;
using Xperience.APIModels;
using System.Text.Json;
using System;

namespace Xperience.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FollowsController : ControllerBase
    {
        private readonly UserManager<BaseUser> _userManager;
        private readonly ApplicationDbContext _dbContext;
        private readonly IWebHostEnvironment _enviromentServices;
        GeneralController general = new GeneralController();
        private readonly UsersController users;


        public FollowsController(
            UserManager<BaseUser> userManager,
            ApplicationDbContext dbContext, IWebHostEnvironment enviromentServices)
        {
            _userManager = userManager;
            _dbContext = dbContext;
            _enviromentServices = enviromentServices;
            users= new UsersController(userManager, dbContext, enviromentServices);

        }
        [HttpGet("{id}")]
        public string GetFollowedAsync(string id)
        {
            List<string >x= _dbContext.FollowedUsers.Where(c => c.ApplicationUserId == id)
                     .Select(x => x.FollowerId)
                     .ToList();

            List<ManageUserModel> z = new List<ManageUserModel>();
            foreach(string i in x)
            {
               // string username= _dbContext.Users.OfType<ApplicationUser>().FirstOrDefault(x => x.Id == i).UserName;
                ApplicationUser user = _dbContext.Users.OfType<ApplicationUser>().FirstOrDefault(x => x.Id == i);
                ManageUserModel model = new ManageUserModel();
                List<int> nationalities = _dbContext.UserNationalities.Where(c => c.ApplicationUserId == i).Select(x => x.NationalityId).ToList();
                List<int> languages = _dbContext.UserLanguages.Where(c => c.ApplicationUserId == i).Select(x => x.LanguageId).ToList();


                if (nationalities.Any())
                {
                    string nations = "";

                    foreach (int y in nationalities)
                    {
                        nations += _dbContext.Nationalities.FirstOrDefault(x => x.Id == y).Name + ",";
                    }

                    nations = nations.Substring(0, nations.Length - 1);
                    model.Nationalities = nations;
                }
                if (languages.Any())
                {
                    string languages1 = "";
                    foreach (int p in languages)
                    {
                        languages1 += _dbContext.Languages.FirstOrDefault(x => x.Id == p).Name + ",";
                    }

                    languages1 = languages1.Substring(0, languages1.Length - 1);
                    model.Languages = languages1;
                }

                if (user.LocationId != null)
                {
                    model.Location = _dbContext.Locations.FirstOrDefault(x => x.Id == user.LocationId).Name;
                }

                if (user.ReligionId != null)
                {
                    model.Religion = _dbContext.Religions.FirstOrDefault(x => x.Id == user.ReligionId).Name;
                }

                model.Id = user.Id;
                model.UserName = user.UserName;
                model.Name = user.Name;
                model.Biography = user.Biography;
                model.DateOfBirth = user.DateOfBirth.ToString();
                model.Gender = user.Gender;
                model.Info = user.Info;
                model.Email = user.Email;
                model.Password = null;
                model.PhoneNumber = user.PhoneNumber;
                model.ProfilePictureName = user.ProfilePicture;
                model.OldPassword = user.PasswordHash.ToString();
                if (user.ConnectorStatus)
                    model.ConnectorStatus = "Enable";
                else
                    model.ConnectorStatus = "Disable";
                z.Add(model);
            }
            var json = JsonSerializer.Serialize(z);
            return json;

           // var users = _dbContext.Users.Select(u => new { id = u.Id });

          //  return Us.Pets.AsQueryable();
        }

        // POST: api/Follows
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/Follows/5
        [HttpPut("{id}")]
        public async Task<ActionResult> PutAsync(string id,string value)
        {

            if (!String.IsNullOrEmpty(value))
            {
                value = value.Substring(0, value.Length - 1);
                List<string> usernames = value.Split(',').ToList();
                List<string> ids = new List<string>();
                foreach (string i in usernames)
                {
                    ids.Add(_dbContext.Users.FirstOrDefault(x => x.UserName == i).Id);

                }


                var NationstoRemove = _dbContext.FollowedUsers
                .Where(x => x.ApplicationUserId == id).ToList();
                _dbContext.FollowedUsers.RemoveRange(NationstoRemove);

                await _dbContext.SaveChangesAsync();
                var users = new List<FollowedUser>();
                foreach (string i in ids)
                {
                    var record = new FollowedUser
                    {
                        ApplicationUserId = id,
                        FollowerId = i,
                    };

                users.Add(record);
                }
                
                var result= _dbContext.FollowedUsers.AddRangeAsync(users);
                await _dbContext.SaveChangesAsync();
                if (result.IsCompletedSuccessfully)
                {
                    return Ok();
                }
                else
                {
                    return BadRequest();
                }
      

            }
            else
            {
                var NationstoRemove = _dbContext.FollowedUsers
.Where(x => x.ApplicationUserId == id ).ToList();
                _dbContext.FollowedUsers.RemoveRange(NationstoRemove);
                await _dbContext.SaveChangesAsync();
                return Ok();
            

            }
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
