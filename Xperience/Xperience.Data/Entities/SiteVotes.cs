using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Xperience.Data.Entities
{
    public class SiteVotes
    {
        [Key, Column(Order = 0)]
        public int User_id { get; set; }
        [Key, Column(Order = 1)]
        public int Site_id { get; set; }
        [Required]
        public bool Vote { get; set; }

        #region F.K

        [ForeignKey("User_id")]
        public  Users Users { get; set; }

        [ForeignKey("Site_id")]
        public  Sites Sites { get; set;}

        #endregion

    }
}
