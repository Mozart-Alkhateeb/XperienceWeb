using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Xperience.Data.Entities.Sites;

namespace Xperience.Data.Entities.Users
{
   public class FollowedSite
    {
        #region F.K

        [Key, Column(Order = 0)]
        public string ApplicationUserId { get; set; }
        [ForeignKey("ApplicationUserId")]
        public  ApplicationUser ApplicationUser { get; set; }

        [Key, Column(Order = 1)]
        public int SiteId { get; set; }
        [ForeignKey("SiteId")]
        public Site Site { get; set; }
        #endregion
    }
}
