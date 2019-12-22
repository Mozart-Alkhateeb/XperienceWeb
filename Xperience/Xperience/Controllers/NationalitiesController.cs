using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Xperience.Data;

namespace Xperience.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NationalitiesController : ControllerBase
    {
        private readonly ApplicationDbContext _dbContext;

        public NationalitiesController(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IActionResult OnGet(string id) {
            var table = (from userLang in _dbContext.UserNationalities
                         join nation in _dbContext.Nationalities on userLang.NationalityId equals nation.Id
                         where userLang.ApplicationUserId == id
                         select new { nation.Id, nation.Name }).ToList();

            return Ok(table);
        }

    }
}