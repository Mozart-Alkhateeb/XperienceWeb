using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Xperience.Data.Entities.Users;

namespace Xperience.Data.Entities.Posts
{
    public class Comment : BaseEntityAutoKey
    {
        #region F.K
        [Column(Order = 1), Required]
        public string ApplicationUserId { get; set; }
        [ForeignKey("ApplicationUserId")]
        public ApplicationUser ApplicationUser { get; set; }

        [Column(Order = 2), Required]
        public int PostId { get; set; }
        [ForeignKey("PostId")]
        public Post Post { get; set; }
        #endregion

        [Column(Order = 3), Required]
        public string CommentDetails { get; set; }
    }
}
