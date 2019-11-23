using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Xperience.Data.Entities.Config;
using Xperience.Data.Entities.Users;

namespace Xperience.Data.Entities.Posts
{
    public class PostReaction
    {
        #region F.K
        [Key, Column(Order = 0)]
        public int PostId { get; set; }
        [ForeignKey("PostId")]
        public Post Post { get; set; }

        [Key, Column(Order = 1)]
        public string ApplicationUserId { get; set; }
        [ForeignKey("ApplicationUserId")]
        public ApplicationUser ApplicationUser { get; set; }

        [Column(Order = 2), Required]
        public int ReactionId { get; set; }
        [ForeignKey("ReactionId")]
        public Reaction Reaction { get; set; }
        #endregion
    }
}
