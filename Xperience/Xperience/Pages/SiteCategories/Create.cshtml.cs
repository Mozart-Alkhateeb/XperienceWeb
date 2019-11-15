using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Xperience.Data;
using Xperience.Data.Entities;

namespace Xperience.Pages.SiteCategories
{
    public class CreateModel : PageModel
    {
        private readonly Xperience.Data.ApplicationDbContext _context;

        public CreateModel(Xperience.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public SiteCategory SiteCategory { get; set; }

        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.SiteCategories.Add(SiteCategory);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
