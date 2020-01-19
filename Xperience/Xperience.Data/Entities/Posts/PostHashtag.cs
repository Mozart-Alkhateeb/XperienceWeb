using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Xperience.Data.Entities.Config;
using Xperience.Data.Entities.Posts;

namespace Xperience.Data.Entities.Posts
{
    public class PostHashtag
    {
        #region F.K

        [Column(Order = 1),Required]
        public int PostId { get; set; }
        [ForeignKey("PostId")]
        public Post Post { get; set; }

        [Column(Order = 2), Required]
        public int HashtagId { get; set; }
        [ForeignKey("HashtagId")]
        public Hashtag Hashtag { get; set; }

        #endregion
    }
}
