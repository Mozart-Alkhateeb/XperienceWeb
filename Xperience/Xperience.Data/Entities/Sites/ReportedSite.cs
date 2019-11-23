using System.ComponentModel.DataAnnotations.Schema;
using Xperience.Data.Entities.Users;

namespace Xperience.Data.Entities.Sites
{
    public class ReportedSite : BaseEntityAutoKey
    {
        #region F.K

        [Column(Order = 1)]
        public string ApplicationUserId { get; set; }
        [ForeignKey("ApplicationUserId")]
        public  ApplicationUser ApplicationUser { get; set; }

        [Column(Order = 2)]
        public int SiteId { get; set; }
        [ForeignKey("SiteId")]
        public Site Site { get; set; }
        #endregion
    }
}
