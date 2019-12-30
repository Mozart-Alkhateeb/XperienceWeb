using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Xperience.Data.Entities.Config;
using Xperience.Data.Entities.Sites;
using Xperience.Data.Entities.Users;

namespace Xperience.Data.Entities.Posts
{
    public class Post : BaseEntityAutoKey
    {
        [Column(Order = 1), Required]
        public string PostDetails { get; set; }

        [Column(Order = 2)]
        public string Caption { get; set; }

        #region F.K

        [Column(Order = 3)]
        public string ApplicationUserId { get; set; }
        [ForeignKey("ApplicationUserId")]
        public ApplicationUser ApplicationUser { get; set; }

        [Column(Order = 4), Required]
        public int SiteId { get; set; }
        [ForeignKey("SiteId")]
        public Site Site { get; set; }

        [Column(Order = 5)]
        public int? HashtagId { get; set; } // ? means that this can be null
        [ForeignKey("HashtagId")]
        public Hashtag Hashtag { get; set; }
        #endregion


        [Column(Order = 6)]
        public DateTime postDate { get; set; }

        #region N.P

        public ICollection<PostReaction> PostReactions { get; set; }

        public ICollection<ReportedPost> ReportedPosts { get; set; }
        public ICollection<Comment> Comments { get; set; }


        public ICollection<Tag> Tags { get; set; }
      
        #endregion
    }
}
