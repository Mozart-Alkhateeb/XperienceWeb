using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Xperience.Data.Entities
{
    public class Posts
    {
        [Key()]
        public int Id { get; set; }
        [Required]
        public int User_id { get; set; }
        [Required]
        public string Post { get; set; }
      
        public string Caption { get; set; }
        [Required]
        public int Site_id { get; set; }
        public int Hashtag_id { get; set; }

        #region F.K

        [ForeignKey("User_id")]
        public Users Posts_user_id { get; set; }

        [ForeignKey("Site_id")]
        public Sites Posts_site_id { get; set; }

        [ForeignKey("Hashtag_id")]
        public Hashtags Posts_hashtag_id { get; set; }

        #endregion


    }
}
