using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Xperience.Data.Entities.Posts;

namespace Xperience.Data.Entities.Config
{
    public class Reaction : BaseEntityAutoKey
    {
        [Column(Order = 1), Required]
        public string IconPath { get; set; }

        // Reaction Text (Person Liked your post, Reacted to your post)
        [Required, MaxLength(250)]
        public string ReactionText { get; set; }


        #region N.P

        public ICollection<PostReaction> PostReactions { get; set; }
        #endregion
    }
}
