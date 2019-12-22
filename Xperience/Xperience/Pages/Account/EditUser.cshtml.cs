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

namespace Xperience.Pages.Account
{
    [Authorize]
    public class EditUserModel : PageModel
    {
        private readonly UserManager<BaseUser> userManager;
        private readonly SignInManager<BaseUser> signInManager;
        private readonly ApplicationDbContext context;
        private BaseUser currentUser;
        private ApplicationUser user;


        public EditUserModel(UserManager<BaseUser> userManager, SignInManager<BaseUser> signInManager,
            ApplicationDbContext context)
        {

            this.userManager = userManager;
            this.signInManager = signInManager;
            this.context = context;
        }



        [BindProperty]
        public InputModel input { get; set; } = new InputModel();

        public class InputModel
        {
            public string name { get; set; }

            public DateTime DOB { get; set; }

            public string gender { get; set; }

            public string Religion { get; set; }

            public string Location { get; set; }

            public string Biography { get; set; }

            public string Info { get; set; }

            public Boolean isConnector { get; set; }

            public List<int> languages { get; set; }

            public List<int> Nationalities { get; set;}
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
            var toRemove = context.UserLanguages
                .Where(x => x.ApplicationUserId == user.Id && !input.languages.Contains(x.LanguageId));
            context.UserLanguages.RemoveRange(toRemove);
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
            var result = await userManager.UpdateAsync(user);
            await context.SaveChangesAsync();
            if (result.Succeeded) return RedirectToPage();
            return BadRequest();
        }


    }
}