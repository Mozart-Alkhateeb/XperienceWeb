using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Xperience.Data.Entities
{
   public class ReactionIcons
    {
        [Key()]
        public int Reaction_id { get; set; }
        [Required]
        public string Icon { get; set; }
    }
}
