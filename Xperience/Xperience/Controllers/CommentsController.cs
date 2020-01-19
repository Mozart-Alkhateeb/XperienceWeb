using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Xperience.Data;
using Xperience.Data.Entities.Users;
using Xperience.APIModels;
using Xperience.Data.Entities.Posts;

namespace Xperience.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentsController : ControllerBase
    {
        private readonly ApplicationDbContext context;
        private readonly UserManager<BaseUser> _userManager;


        public CommentsController(ApplicationDbContext dbContext, UserManager<BaseUser> userManager)
        {
            context = dbContext;
            _userManager = userManager;
        }

        [HttpPost("{pageNumber},{nOfComments},{postId}")]
        public IActionResult OnPost(int pageNumber, int nOfComments, int postId) {
            int skip = nOfComments * (pageNumber - 1);

            var result = context.Comments.Where(x => x.PostId == postId).Skip(skip)
                .Select(x => new
                {
                    id = x.Id,
                    comment = x.CommentDetails,
                    name = x.ApplicationUser.Name,
                    x.date
                }).OrderByDescending(x => x.date).Take(nOfComments).ToList();

            return Ok(result);
        }

        [HttpPost]
        public async Task OnPost([FromForm] ManageCommentModel model) {
            var newComment = new Comment()
            {
                ApplicationUserId = _userManager.GetUserId(HttpContext.User),
                CommentDetails = model.CommentDetails,
                date = DateTime.Now,
                PostId = model.postId
            };

            await context.AddAsync(newComment);
            await context.SaveChangesAsync();
        }
    }
}