using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Xperience.Data;
using Xperience.Data.Entities;

namespace Xperience.Pages.SiteCategories
{
    public class EditModel : PageModel
    {
        private readonly Xperience.Data.ApplicationDbContext _context;

        public EditModel(Xperience.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public SiteCategory SiteCategory { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            SiteCategory = await _context.SiteCategories.FirstOrDefaultAsync(m => m.Id == id);

            if (SiteCategory == null)
            {
                return NotFound();
            }
            return Page();
        }

        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(SiteCategory).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SiteCategoryExists(SiteCategory.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool SiteCategoryExists(int id)
        {
            return _context.SiteCategories.Any(e => e.Id == id);
        }
    }
}
