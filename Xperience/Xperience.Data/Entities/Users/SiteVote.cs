using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Xperience.Data.Entities.Sites;

namespace Xperience.Data.Entities.Users
{
    public class SiteVote : BaseEntityAutoKey
    {
        #region F.K

        [Column(Order = 1)]
        public string ApplicationUserId { get; set; }
        [ForeignKey("ApplicationUserId")]
        public ApplicationUser ApplicationUser { get; set; }

        [Column(Order = 2), Required]
        public int SiteId { get; set; }
        [ForeignKey("SiteId")]
        public Site Site { get; set; }
        #endregion

        [Column(Order = 3), Required]
        public bool Vote { get; set; }
    }
}
