using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.InteropServices.ComTypes;
using Xperience.Data.Entities.Users;

namespace Xperience.Data.Entities.Config
{
    public class Rating : BaseEntityAutoKey
    {
        #region F.K
        [Column(Order = 1)]
        public string ApplicationUserId { get; set; }
        [ForeignKey("ApplicationUserId")]
        public ApplicationUser ApplicationUser { get; set; }

        [Column(Order = 2)]
        public string RatedId { get; set; }
        [ForeignKey("RatedId")]
        public ApplicationUser Rated { get; set; }
        #endregion

        [Column(Order = 3), Required]
        public float RatingValue { get; set; }
    }
}
