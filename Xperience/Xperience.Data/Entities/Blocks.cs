using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Xperience.Data.Entities
{
    public class Blocks
    {
        [Key, Column(Order = 0)]
        public int Blocker_id { get; set; }

        [Key, Column(Order = 1)]
        public int Blocked_id { get; set; }


        [ForeignKey("Blocker_id")]
        public Users Blocker { get; set; }

        [ForeignKey("Blocked_id")]
        public Users Blocked { get; set; }

    }
}
