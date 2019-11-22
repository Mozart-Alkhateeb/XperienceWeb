using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Xperience.Data.Entities
{
    public class Reactions
    {

        [Key, Column(Order = 0)]
        public int User_id { get; set; }
        [Required]
        public int Reaction_id { get; set; }

        [Key, Column(Order = 1)]
        public int Post_id { get; set; }

        #region F.K

        [ForeignKey("User_id")]
        public Users Users { get; set; }

        [ForeignKey("Reaction_id")]
        public ReactionIcons Reaction_Icons { get; set; }

        [ForeignKey("Post_id")]
        public Posts Posts { get; set; }



        #endregion

    }
}
