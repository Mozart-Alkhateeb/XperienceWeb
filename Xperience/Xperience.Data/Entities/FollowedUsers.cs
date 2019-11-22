using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Xperience.Data.Entities
{
    public class FollowedUsers
    {
        [Key, Column(Order = 0)]
        public int Follower_id { get; set; }

        [Key, Column(Order = 1)]
        public int Followed_id { get; set; }

        #region F.K

        [ForeignKey("Follower_id")]
        public Users FollowerUser { get; set; }

        [ForeignKey("Followed_id")]
        public Users FollowedUser { get; set; }

        #endregion

    }
}
