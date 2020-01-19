using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Xperience.Data.Entities.Users;
using Xperience.Data;
using Xperience.Data.Entities.Config;
using Microsoft.AspNetCore.Http;
using System.IO;
using Microsoft.AspNetCore.Hosting;

namespace Xperience.Pages.Account
{
    [Authorize]
    public class EditUserModel : PageModel
    {
        private readonly UserManager<BaseUser> userManager;
        private readonly SignInManager<BaseUser> signInManager;
        private readonly ApplicationDbContext context;
        private readonly IWebHostEnvironment enviromentServices;
        private BaseUser currentUser;
        private ApplicationUser user;


        [BindProperty]
        public InputModel input { get; set; } = new InputModel();

        public class InputModel
        {
            public IFormFile image { get; set; }

            public string name { get; set; }

            public DateTime DOB { get; set; }

            public string gender { get; set; }

            public string Religion { get; set; }

            public string Location { get; set; }

            public string Biography { get; set; }

            public string Info { get; set; }

            public Boolean isConnector { get; set; }

            public List<int> languages { get; set; } = new List<int>();

            public List<int> Nationalities { get; set;} = new List<int>();
        }

        public EditUserModel(UserManager<BaseUser> userManager, SignInManager<BaseUser> signInManager,
            ApplicationDbContext context, IWebHostEnvironment enviromentServices)
        {

            this.userManager = userManager;
            this.signInManager = signInManager;
            this.context = context;
            this.enviromentServices = enviromentServices;
        }

        public async Task OnGetAsync()
        {
            currentUser = await userManager.GetUserAsync(HttpContext.User);



            user = context.Users.OfType<ApplicationUser>().FirstOrDefault(x => x.Id == currentUser.Id);
            input.Biography = user.Biography;
            input.Info = user.Info;
        }


        public async Task<IActionResult> OnPostAsync()
        {


            if (!ModelState.IsValid)
            {
                return Page();
            }

            currentUser = await userManager.GetUserAsync(HttpContext.User);


            if (currentUser == null)
            {
                return Redirect("~/index");
            }
            user = context.Users.OfType<ApplicationUser>().FirstOrDefault(x => x.Id == currentUser.Id);
            user.Name = input.name;
            user.DateOfBirth = input.DOB;
            user.Gender = input.gender;
            if (input.Religion == null)
            {
                user.ReligionId = null;
            }
            else
            {
                var religion = context.Religions.FirstOrDefault(x => x.Name == input.Religion);
                if (religion == null)
                {
                    var newRel = new Religion()
                    {
                        Name = input.Religion
                    };
                    await context.AddAsync(newRel);
                    await context.SaveChangesAsync();
                }
                user.ReligionId = context.Religions.FirstOrDefault(x => x.Name == input.Religion).Id;
            }
            if (input.Location == null)
            {
                user.LocationId = null;
            }
            else
            {
                var location = context.Locations.FirstOrDefault(x => x.Name == input.Location);
                if (location == null)
                {
                    var newLoc = new Location()
                    {
                        Name = input.Location
                    };
                    await context.AddAsync(newLoc);
                    await context.SaveChangesAsync();
                }
                user.LocationId = context.Locations.FirstOrDefault(x => x.Name == input.Location).Id;
            }
            user.Biography = input.Biography;
            user.ConnectorStatus = input.isConnector;
            if (input.isConnector)
            {
                user.Info = input.Info;
            }
            var LangstoRemove = context.UserLanguages
                .Where(x => x.ApplicationUserId == user.Id && !input.languages.Contains(x.LanguageId)).ToList();
            context.UserLanguages.RemoveRange(LangstoRemove);
            foreach (int i in input.languages)
            {
                var checkResult = context.UserLanguages.FirstOrDefault(x => x.LanguageId == i
                && x.ApplicationUserId == user.Id);
                if (checkResult == null)
                {
                    var lang = new UserLanguage()
                    {
                        ApplicationUserId = user.Id,
                        LanguageId = i
                    };
                    await context.UserLanguages.AddAsync(lang);
                }
            }

            var NationstoRemove = context.UserNationalities
                .Where(x => x.ApplicationUserId == user.Id && !input.Nationalities.Contains(x.NationalityId)).ToList();
            context.UserNationalities.RemoveRange(NationstoRemove);
            foreach (int i in input.Nationalities)
            {
                var checkResult = context.UserNationalities.FirstOrDefault(x => x.NationalityId == i
                && x.ApplicationUserId == user.Id);
                if (checkResult == null)
                {
                    var nation = new UserNationality()
                    {
                        ApplicationUserId = user.Id,
                        NationalityId = i
                    };
                    await context.UserNationalities.AddAsync(nation);
                }
            }

            if (input.image != null) {
                string upload = Path.Combine(enviromentServices.WebRootPath, "Images");
                upload = Path.Combine(upload, "ProfilePictures");
                string fileName = Guid.NewGuid().ToString() + "_" + input.image.FileName;
                upload = Path.Combine(upload, fileName);
                input.image.CopyTo(new FileStream(upload, FileMode.Create));
            }
            var result = await userManager.UpdateAsync(user);
            await context.SaveChangesAsync();
            if (result.Succeeded) return RedirectToPage();
            return BadRequest();
        }


    }
}