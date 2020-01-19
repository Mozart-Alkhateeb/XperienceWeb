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
using Microsoft.AspNetCore.Hosting;
using System.IO;

namespace Xperience.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostsController : ControllerBase
    {

        private readonly ApplicationDbContext context;
        private readonly UserManager<BaseUser> _userManager;
        private readonly IWebHostEnvironment enviromentServices;


        public PostsController(ApplicationDbContext dbContext, UserManager<BaseUser> userManager, IWebHostEnvironment hostEnvironment)
        {
            context = dbContext;
            _userManager = userManager;
            enviromentServices = hostEnvironment;
        }

        [HttpPost("{pageNumber},{nOfPosts}")]
        public IActionResult OnPost(int pageNumber, int nOfPosts)
        {
            var Id = _userManager.GetUserId(HttpContext.User);

            int skip = nOfPosts * (pageNumber - 1);


            var posts = context.Posts
            .Where(x => (context.FollowedUsers
            .FirstOrDefault(n => n.FollowerId == Id && n.ApplicationUserId == x.ApplicationUserId)) != null
            || (context.FollowedSites.FirstOrDefault(n => n.ApplicationUserId == Id && n.SiteId == x.SiteId) != null)
            || x.ApplicationUserId == Id)
            .Skip(skip)
            .Select(x => new
            {
                id = x.Id,
                name = x.ApplicationUser.Name,
                site = x.Site.Name,
                hashtag = x.Hashtag.Name,
                postDetails = x.PostDetails,
                postDate = x.postDate,
                caption = x.Caption
            })
            .OrderByDescending(x => x.postDate).Take(nOfPosts).ToList();



            return Ok(posts);

        }



        [HttpPost]
        public async Task OnPostAsync([FromForm]ManagePostModel newPost)
        {
            string upload = Path.Combine(enviromentServices.WebRootPath, "Images");
            upload = Path.Combine(upload, "PostPictures");
            string fileName = Guid.NewGuid().ToString() + "_" + newPost.PostDetails.FileName;
            upload = Path.Combine(upload, fileName);
            newPost.PostDetails.CopyTo(new FileStream(upload, FileMode.Create));


             var post = new Post()
             {
                 PostDetails = fileName,
                 ApplicationUserId = _userManager.GetUserId(HttpContext.User),
                 Caption = newPost.Caption,
                 SiteId = context.Sites.FirstOrDefault(x => x.Name == newPost.Site).Id,
                 HashtagId = context.Hashtags.FirstOrDefault(x => x.Name == newPost.Hashtag).Id,
                 postDate = DateTime.Now
             };

             await context.AddAsync(post);
             await context.SaveChangesAsync();
        }

    }
}