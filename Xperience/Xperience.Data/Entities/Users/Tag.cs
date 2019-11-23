using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Xperience.Data.Entities.Posts;

namespace Xperience.Data.Entities.Users
{
    public class Tag : BaseEntityAutoKey
    {
        #region F.K

        [Column(Order = 1), Required]
        public string ApplicationUserId { get; set; }
        [ForeignKey("ApplicationUserId")]
        public ApplicationUser ApplicationUser { get; set; }

        [Column(Order = 2), Required]
        public string TaggedId { get; set; }
        [ForeignKey("TaggedId")]
        public ApplicationUser Tagged { get; set; }

        [Column(Order = 3), Required]
        public int PostId { get; set; }
        [ForeignKey("PostId")]
        public Post Post { get; set; }
        #endregion
    }
}
