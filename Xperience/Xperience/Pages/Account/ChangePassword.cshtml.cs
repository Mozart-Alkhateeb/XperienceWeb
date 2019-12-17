using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Xperience.Data;
using Xperience.Data.Entities.Users;

namespace Xperience.Pages.Account
{
    public class ChangePasswordModel : PageModel
    {

        private readonly UserManager<BaseUser> userManager;
        private readonly SignInManager<BaseUser> signInManager;
        private BaseUser currentUser;
        private ApplicationUser user;


        public ChangePasswordModel(UserManager<BaseUser> userManager, SignInManager<BaseUser> signInManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
        }

        [BindProperty]
        public InputModel input { get; set; } = new InputModel();


        public class InputModel { 
            [Required]
            [DataType(DataType.Password)]
            public string oldPassword { get; set; }

            [Required]
            [DataType(DataType.Password)]
            [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
            public string newPassword { get; set; }

            [Required]
            [DataType(DataType.Password)]
            [Compare("newPassword", ErrorMessage = "The password and confirmation password do not match.")]
            public string confirmPassword { get; set; }
        }

        public async void OnGetAsync() {
            currentUser = await userManager.GetUserAsync(HttpContext.User);
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (ModelState.IsValid)
            {



                currentUser = await userManager.GetUserAsync(HttpContext.User);

                if (currentUser == null)
                {
                    RedirectToPage("Login");
                }


                var result = await userManager.ChangePasswordAsync(currentUser, input.oldPassword, input.newPassword);

                if (result.Succeeded)
                {
                    return Redirect("~/PassChangeSuccess");
                }

                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }

            }
            return Page();
        }
    }
}