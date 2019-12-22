using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Xperience.Data;
using Xperience.Data.Entities.Users;

namespace Xperience.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LanguagesController : ControllerBase
    {

        private readonly ApplicationDbContext _dbContext;

        public LanguagesController(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        [HttpGet]
        public IActionResult OnGet(string id)
        {
            var table = (from userLang in _dbContext.UserLanguages
                         join lang in _dbContext.Languages on userLang.LanguageId equals lang.Id
                         where userLang.ApplicationUserId == id
                         select new { lang.Id , lang.Name }).ToList();

            return Ok(table);
        }

    }
}