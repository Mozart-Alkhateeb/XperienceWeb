using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Xperience.Data.Entities.Users
{
    public class FollowedUser
    {
        #region F.K
        [Key, Column(Order = 0)]
        public string ApplicationUserId { get; set; }
        [ForeignKey("ApplicationUserId")]
        public ApplicationUser ApplicationUser { get; set; }

        [Key, Column(Order = 1)]
        public string FollowerId { get; set; }
        [ForeignKey("FollowerId")]
        public ApplicationUser Follower { get; set; }
        #endregion
    }
}
