using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Xperience.Data;
using Xperience.Data.Entities;

namespace Xperience.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SitesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public SitesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Sites
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Users>>> GetSites()
        {
            return await _context.Sites.ToListAsync();
        }

        // GET: api/Sites/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Users>> GetSite(int id)
        {
            var site = await _context.Sites.FindAsync(id);

            if (site == null)
            {
                return NotFound();
            }

            return site;
        }

        // PUT: api/Sites/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSite(int id, Users site)
        {
            if (id != site.Id)
            {
                return BadRequest();
            }

            _context.Entry(site).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SiteExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Sites
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<Users>> PostSite(Users site)
        {
            _context.Sites.Add(site);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSite", new { id = site.Id }, site);
        }

        // DELETE: api/Sites/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Users>> DeleteSite(int id)
        {
            var site = await _context.Sites.FindAsync(id);
            if (site == null)
            {
                return NotFound();
            }

            _context.Sites.Remove(site);
            await _context.SaveChangesAsync();

            return site;
        }

        private bool SiteExists(int id)
        {
            return _context.Sites.Any(e => e.Id == id);
        }
    }
}
