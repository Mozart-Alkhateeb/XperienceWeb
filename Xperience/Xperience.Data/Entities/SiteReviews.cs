using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Xperience.Data.Entities
{
    public class SiteReviews
    {
        [Key()]
        public int Id { get; set; }

        [Required]

        public int Reviewer_id { get; set; }
        [Required]
        public int Site_id { get; set; }

        [Required]
        public string Review { get; set; }
        [Required]

        public DateTime Time { get; set; }

        #region F.K

        [ForeignKey("Reviewer_id")]
        public Users Users { get; set; }

        [ForeignKey("Site_id")]
        public Sites Sites { get; set; }

        #endregion

    }
}
