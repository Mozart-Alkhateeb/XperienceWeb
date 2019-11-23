using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Xperience.Data.Entities.Config;

namespace Xperience.Data.Entities.Users
{
   public class UserInterest
    {
        #region F.K
        [Key, Column(Order = 0)]
        public string ApplicationUserId { get; set; }
        [ForeignKey("ApplicationUserId")]
        public ApplicationUser ApplicationUser { get; set; }

        [Key, Column(Order = 1)]
        public int CategoryId { get; set; }
        [ForeignKey("CategoryId")]
        public Category Category { get; set; }
        #endregion
    }
}
