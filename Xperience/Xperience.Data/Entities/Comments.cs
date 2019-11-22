using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Xperience.Data.Entities
{
   public class Comments
    {
        [Key()]
        public int Id { get; set; }
        [Required]
        public int User_id { get; set; }
        [Required]
        public int Post_id { get; set; }
        [Required]
        public string Comment { get; set; }

        [ForeignKey("User_id")]
        public Users Comment_user_id { get; set; }

        [ForeignKey("Post_id")]
        public Posts Comment_post_id { get; set; }
    }
}
