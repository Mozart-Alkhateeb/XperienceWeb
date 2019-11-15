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
    public class DetailsModel : PageModel
    {
        private readonly Xperience.Data.ApplicationDbContext _context;

        public DetailsModel(Xperience.Data.ApplicationDbContext context)
        {
            _context = context;
        }

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
    }
}
