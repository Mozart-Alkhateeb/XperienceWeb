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
    public class IndexModel : PageModel
    {
        private readonly Xperience.Data.ApplicationDbContext _context;

        public IndexModel(Xperience.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<SiteCategory> SiteCategory { get;set; }

        public async Task OnGetAsync()
        {
            SiteCategory = await _context.SiteCategories.ToListAsync();
        }
    }
}
