using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Xperience.Data;
using Xperience.Data.Entities;

namespace Xperience.Pages.Sites
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
        ViewData["SiteCategoryId"] = new SelectList(_context.SiteCategories, "Id", "Description");
            return Page();
        }

        [BindProperty]
        public Site Site { get; set; }

        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Sites.Add(Site);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
