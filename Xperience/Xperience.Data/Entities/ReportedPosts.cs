using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Xperience.Data.Entities
{
    public class ReportedPosts
    {
        [Key, Column(Order = 0)]
        public int Reporter_id { get; set; }
        [Key, Column(Order = 1)]
        public int Post_id { get; set; }


        [ForeignKey("Reporter_id")]
        public Users Reported_posts_user { get; set; }

        [ForeignKey("Post_id")]
        public Posts Reported_post_id { get; set; }


    }
}
