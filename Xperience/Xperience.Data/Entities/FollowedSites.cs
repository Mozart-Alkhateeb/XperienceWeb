using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Xperience.Data.Entities
{
   public class FollowedSites
    {
        [Key, Column(Order = 0)]
        public int Follower_id { get; set; }

        [Key, Column(Order = 1)]
        public int Followed_id { get; set; }

        #region F.K

        [ForeignKey("Follower_id")]
        public  Users Followed_sites_user { get; set; }

        [ForeignKey("Followed_id")]
        public Sites Followed_sites_id { get; set; }

        #endregion
    }
}
