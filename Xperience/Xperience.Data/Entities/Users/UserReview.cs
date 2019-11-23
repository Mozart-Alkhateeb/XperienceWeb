using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Xperience.Data.Entities.Users
{
    public class UserReview :BaseEntityAutoKey
    {
        [Column(Order = 1)]
        [Required]
        public string Review { get; set; }

        [Column(Order = 2)]
        [Required]
        public DateTime ReviewDate { get; set; }

        #region F.K
        [Column(Order = 3)]
        public string ApplicationUserId { get; set; }
        [ForeignKey("ApplicationUserId")]
        public ApplicationUser ApplicationUser { get; set; }

        [Column(Order = 4)]
        public string ReviewedId { get; set; }
        [ForeignKey("ReviewedId")]
        public ApplicationUser Reviewed { get; set; }
        #endregion
    }
}
