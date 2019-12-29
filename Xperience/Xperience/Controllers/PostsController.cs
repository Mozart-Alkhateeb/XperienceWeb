using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Xperience.Data;
using Xperience.Data.Entities.Users;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Xperience.APIModels;
using Xperience.Data.Entities.Posts;

namespace Xperience.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostsController : ControllerBase
    {

        private readonly ApplicationDbContext context;
        private readonly UserManager<BaseUser> _userManager;
        private BaseUser currentUser;
        private ApplicationUser user;

        
        public PostsController(ApplicationDbContext dbContext, UserManager<BaseUser> userManager)
        {
            context = dbContext;
            _userManager = userManager;
        }

        [HttpPost]
        public async Task<IActionResult> OnPostAsync(int pageNumber, int nOfPosts) {
            currentUser = await _userManager.GetUserAsync(HttpContext.User);
            user = context.Users.OfType<ApplicationUser>().FirstOrDefault(x => x.Id == currentUser.Id);

            int skip = nOfPosts * (pageNumber - 1);


            var posts = context.Posts
            .Where(x => (context.FollowedUsers
            .FirstOrDefault(n => n.FollowerId == user.Id && n.ApplicationUserId == x.ApplicationUserId)) != null
            || (context.FollowedSites.FirstOrDefault(n => n.ApplicationUserId == user.Id && n.SiteId == x.SiteId) != null) || x.ApplicationUserId == user.Id)
            .OrderByDescending(x => x.postDate).Skip(skip).Take(nOfPosts).ToList();

            return Ok(posts);
        }

        [HttpPost]
        public async void OnPostAsync(ManagePostModel model) {
            currentUser = await _userManager.GetUserAsync(HttpContext.User);
            user = context.Users.OfType<ApplicationUser>().FirstOrDefault(x => x.Id == currentUser.Id);

            var post = new Post()
            {
                PostDetails = model.PostDetails,
                ApplicationUserId = user.Id,
                Caption = model.Caption,
                SiteId = context.Sites.FirstOrDefault(x => x.Name == model.Site).Id,
                HashtagId = context.Hashtags.FirstOrDefault(x => x.Name == model.Hashtag).Id,
                postDate = DateTime.Now
            };

            await context.AddAsync(post);
            context.SaveChanges();
        }

    }
}