using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Xperience.Data.Entities.Users
{
    public class Connection
    {
        #region F.K
        [Key, Column(Order = 0)]
        public string ApplicationUserId { get; set; }
        [ForeignKey("ApplicationUserId")]
        public ApplicationUser ApplicationUser { get; set; }

        [Key, Column(Order = 1)]
        public string ConnectedId { get; set; }
        [ForeignKey("ConnectedId")]
        public ApplicationUser Connected { get; set; }
        #endregion
    }
}
