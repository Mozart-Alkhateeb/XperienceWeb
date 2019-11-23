using System.ComponentModel.DataAnnotations.Schema;

namespace Xperience.Data.Entities.Users
{
    public class ReportedUser : BaseEntityAutoKey
    {
        #region F.K

        [Column(Order = 0)]
        public string ApplicationUserId { get; set; }
        [ForeignKey("ApplicationUserId")]
        public ApplicationUser ApplicationUser { get; set; }

        [Column(Order = 1)]
        public string ReportedId { get; set; }
        [ForeignKey("ReportedId")]
        public ApplicationUser Reported { get; set; }

        #endregion
    }
}
