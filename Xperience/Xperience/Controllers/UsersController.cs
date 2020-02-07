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
using Xperience.Data.Entities.Config;
using Xperience.Data.Entities.Config;
using Microsoft.AspNetCore.Hosting;
using System.IO;
using System;
using System.Text.Json;
using Amazon.CloudFront.Model;

namespace Xperience.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly UserManager<BaseUser> _userManager;
        private readonly ApplicationDbContext _dbContext;
        private readonly IWebHostEnvironment _enviromentServices;
        GeneralController general = new GeneralController();


        public UsersController(
            UserManager<BaseUser> userManager,
            ApplicationDbContext dbContext, IWebHostEnvironment enviromentServices)
        {
            _userManager = userManager;
            _dbContext = dbContext;
            _enviromentServices = enviromentServices;

        }

        [HttpGet("{id}")]
        public async Task<ActionResult<string>> GetAsync(String id)
        {
            ApplicationUser user = _dbContext.Users.OfType<ApplicationUser>().FirstOrDefault(x => x.Id == id);
            if (user == null)
                return BadRequest();
            return Ok(user);
        }


        [HttpPut]
        public async Task<ActionResult> PutAsync([FromForm]ManageUserModel model)
        {
            List<string> nationalities = new List<string>();
            List<string> languages = new List<string>();


            if (model.Nationalities != null)
            {
                if (model.Nationalities.EndsWith(','))
                {
                    return BadRequest("Remove , appended at the end of Nationalities");
                }

                nationalities = model.Nationalities.Split(',').ToList();
            }

            if (model.Languages != null)
            {
                languages = model.Languages.Split(',').ToList();
                if (model.Languages.EndsWith(','))
                {
                    return BadRequest("Remove , appended at the end of Languages");
                }
            }


            if (!ModelState.IsValid)
                return BadRequest("Not a valid model");
            BaseUser currentUser = new BaseUser();

            using (var ctx = new ApplicationDbContext())
            {
                ApplicationUser user = _dbContext.Users.OfType<ApplicationUser>().FirstOrDefault(x => x.Id == model.Id);
                if (model.Name != null)
                    user.Name = model.Name;
                if (model.DateOfBirth != null)
                    user.DateOfBirth = Convert.ToDateTime(model.DateOfBirth);
                if (model.Gender != null)
                    user.Gender = model.Gender;
                if (model.Email != null)
                    user.Email = model.Email;
                if (model.PhoneNumber != null)
                    user.PhoneNumber = model.PhoneNumber;
                if (model.Info != null)
                    user.Info = model.Info;
                // currentUser = await _userManager.FindByIdAsync(model.Id);
                IdentityResult z;
                if (model.Password != null)
                {
                    z = await _userManager.ChangePasswordAsync(user, model.OldPassword, model.Password);


                    if (!z.Succeeded)
                    {
                        return BadRequest("Incorrect Password");
                    }

                }

                if (model.Religion == null)
                {
                    user.ReligionId = null;
                }
                else
                {
                    var religion = _dbContext.Religions.FirstOrDefault(x => x.Name == model.Religion);
                    if (religion == null)
                    {
                        var newRel = new Religion()
                        {
                            Name = model.Religion
                        };
                        await _dbContext.AddAsync(newRel);
                        await _dbContext.SaveChangesAsync();
                    }
                    user.ReligionId = _dbContext.Religions.FirstOrDefault(x => x.Name == model.Religion).Id;
                }
                if (model.Location == null)
                {
                    user.LocationId = null;
                }
                else
                {
                    var location = _dbContext.Locations.FirstOrDefault(x => x.Name == model.Location);
                    if (location == null)
                    {
                        var newLoc = new Location()
                        {
                            Name = model.Location
                        };
                        await _dbContext.AddAsync(newLoc);
                        await _dbContext.SaveChangesAsync();
                    }
                    user.LocationId = _dbContext.Locations.FirstOrDefault(x => x.Name == model.Location).Id;
                }
                if (model.Biography != null)
                    user.Biography = model.Biography;
                if (model.ConnectorStatus == "enable")
                {
                    user.ConnectorStatus = true;
                }
                else
                {
                    user.ConnectorStatus = false;
                }
                if (user.ConnectorStatus)
                {
                    user.Info = model.Info;
                }
                var LangstoRemove = _dbContext.UserLanguages
                    .Where(x => x.ApplicationUserId == user.Id && !languages.Contains(x.Language.Name)).ToList();
                _dbContext.UserLanguages.RemoveRange(LangstoRemove);
                foreach (string i in languages)
                {
                    var checkResult = _dbContext.UserLanguages.FirstOrDefault(x => x.Language.Name.Equals(i)
                    && x.ApplicationUserId == user.Id);

                    if (checkResult == null)
                    {


                        var checkResult2 = _dbContext.Languages.AsNoTracking().Where(t => t.Name.Equals(i)).FirstOrDefault();



                        if (checkResult2 == null)
                        {
                            var language1 = new Language();
                            int p1 = _dbContext.Languages.Max(m => (int?)m.Id) ?? 0;
                            if (general.checknull(p1))
                            {
                                p1 = 1;
                            }
                            else
                            {
                                p1++;
                            }
                            language1.Name = i.ToLower();

                            await _dbContext.Languages.AddAsync(language1);

                            var language = new UserLanguage()
                            {
                                ApplicationUserId = user.Id,
                                LanguageId = p1
                            };
                            await _dbContext.UserLanguages.AddAsync(language);

                            await _dbContext.SaveChangesAsync();
                        }
                        else
                        {
                            var language = new UserLanguage()
                            {
                                ApplicationUserId = user.Id,
                                LanguageId = checkResult2.Id
                            };
                            await _dbContext.UserLanguages.AddAsync(language);
                            await _dbContext.SaveChangesAsync();

                        }


                    }

                }

                var NationstoRemove = _dbContext.UserNationalities
                    .Where(x => x.ApplicationUserId == user.Id && !nationalities.Contains(x.Nationality.Name)).ToList();
                _dbContext.UserNationalities.RemoveRange(NationstoRemove);
                foreach (string i in nationalities)
                {
                    var checkResult = _dbContext.UserNationalities.FirstOrDefault(x => x.Nationality.Name.Equals(i)
                    && x.ApplicationUserId == user.Id);

                    if (checkResult == null)
                    {
                        var checkResult2 = _dbContext.Nationalities.AsNoTracking().Where(t => t.Name.Equals(i)).FirstOrDefault();



                        if (checkResult2 == null)
                        {

                            var nationality = new Nationality();
                            int p1 = _dbContext.Nationalities.Max(m => (int?)m.Id) ?? 0;
                            if (general.checknull(p1))
                            {
                                p1 = 1;
                            }
                            else
                            {
                                p1++;
                            }
                            nationality.Name = i.ToLower();

                            await _dbContext.Nationalities.AddAsync(nationality);

                            var nationality1 = new UserNationality()
                            {
                                ApplicationUserId = user.Id,
                                NationalityId = p1
                            };
                            await _dbContext.UserNationalities.AddAsync(nationality1);
                            await _dbContext.SaveChangesAsync();

                        }
                        else
                        {
                            var nationality1 = new UserNationality()
                            {
                                ApplicationUserId = user.Id,
                                NationalityId = checkResult2.Id
                            };
                            await _dbContext.UserNationalities.AddAsync(nationality1);
                            await _dbContext.SaveChangesAsync();

                        }


                    }
                }

                string fileName = "";
                if (model.ProfilePicture != null)
                {
                    string upload = Path.Combine(_enviromentServices.WebRootPath, "Images");
                    upload = Path.Combine(upload, "ProfilePictures");
                    fileName = Guid.NewGuid().ToString() + "_" + model.ProfilePicture.FileName;
                    upload = Path.Combine(upload, fileName);
                    model.ProfilePicture.CopyTo(new FileStream(upload, FileMode.Create));
                    user.ProfilePicture = "Images/ProfilePictures/" + fileName;
                    // user.Ext = model.Ext;
                    await _dbContext.SaveChangesAsync();

                }

                var result = await _userManager.UpdateAsync(user);
                await _dbContext.SaveChangesAsync();
                if (result.Succeeded)
                {

                    String ret;
                    if (fileName != null)
                    {
                        ret = "Images/ProfilePictures/" + fileName;
                        return Ok(ret);

                    }

                    return Ok();
                }



                return BadRequest("aaaaa");

            }
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
                    DateOfBirth = Convert.ToDateTime(newUser.DateOfBirth),
                    Gender = newUser.Gender,
                    ProfilePicture = "Images/Default/img_184513.png"

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
        [Route("getUser/{username}")]
        public string getUser(string username)
        {
            ApplicationUser user = _dbContext.Users.OfType<ApplicationUser>().FirstOrDefault(x => x.UserName == username);
            //BaseUser user2= _dbContext.Users.FirstOrDefault(x => x.UserName == username);
            ManageUserModel model = new ManageUserModel();
            //List<UserNationality> nationality= _dbContext.UserNationalities.FirstOrDefault(x => x.ApplicationUserId == user.Id);
            List<int>nationalities= _dbContext.UserNationalities.Where(c => c.ApplicationUserId == user.Id).Select(x => x.NationalityId).ToList();
            List<int> languages = _dbContext.UserLanguages.Where(c => c.ApplicationUserId == user.Id).Select(x => x.LanguageId).ToList();

           

            if (nationalities.Any()) {
                string nations = "";

                foreach (int i in nationalities)
                {
                    nations += _dbContext.Nationalities.FirstOrDefault(x => x.Id == i).Name + ",";
                }

                nations = nations.Substring(0, nations.Length - 1);
                model.Nationalities = nations;
            }
            if (languages.Any()) {
                string languages1 = "";
                foreach (int i in languages)
                {
                    languages1 += _dbContext.Languages.FirstOrDefault(x => x.Id == i).Name+",";
                }

                languages1 = languages1.Substring(0, languages1.Length - 1);
                model.Languages = languages1;
            }
          
            if (user.LocationId != null)
            {        
               model.Location= _dbContext.Locations.FirstOrDefault(x => x.Id == user.LocationId).Name;
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
            if(user.ConnectorStatus)
            model.ConnectorStatus = "Enable";
            else
                model.ConnectorStatus = "Disable";


            var json = JsonSerializer.Serialize(model);
            return json;
            /* if (user.ConnectorStatus)
                 model.ConnectorStatus = "1";
             else
                 model.ConnectorStatus = "0";*/

       

        }



    }
}