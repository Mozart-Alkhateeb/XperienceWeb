using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Xperience.Data.Entities.Sites;

namespace Xperience.Data.Entities.Users
{
    public class UserSiteReview : BaseEntityAutoKey
    {
        [Column(Order = 1), Required]
        public string Review { get; set; }

        [Column(Order = 2), Required]
        public DateTime ReviewDate { get; set; }

        #region F.K

        [Column(Order = 3)]
        public string ApplicationUserId { get; set; }
        [ForeignKey("ApplicationUserId")]
        public ApplicationUser ApplicationUser { get; set; }

        [Column(Order = 4), Required]
        public int SiteId { get; set; }
        [ForeignKey("SiteId")]
        public Site Site { get; set; }
        #endregion
    }
}
