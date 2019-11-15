using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Xperience.Data;
using Xperience.Data.Entities;

namespace Xperience.Pages.SiteCategories
{
    public class DeleteModel : PageModel
    {
        private readonly Xperience.Data.ApplicationDbContext _context;

        public DeleteModel(Xperience.Data.ApplicationDbContext context)
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

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            SiteCategory = await _context.SiteCategories.FindAsync(id);

            if (SiteCategory != null)
            {
                //this is translated to sql
                //_context.Sites.RemoveRange(_context.Sites.Where(q=>q.SiteCategoryId == id));
                //_context.SiteCategories.Remove(SiteCategory);

                _context.Database.ExecuteSqlRaw($@"
                
                DELETE FROM Sites WHERE SiteCategoryId = {id};
                DELETE FROM SiteCategories WHERE Id = {id};
");

                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
