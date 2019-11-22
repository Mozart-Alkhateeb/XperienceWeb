using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Xperience.Data.Entities
{
    public class Sites
    {
        [Key()]
        public int Id { get; set; }
        [Required]
        public int Name { get; set; }
        [Required]
        public float Latitude  { get; set; }
        [Required]
        public float Longitude { get; set; }
        [Required]
        public int Category_id { get; set; }
        [Required]
        public int Location_id { get; set; }

        #region F.K

        [ForeignKey("Category_id")]
        public Categories Categories { get; set; }

        [ForeignKey("Location_id")]
        public Locations Locations { get; set; }

        #endregion

        #region N.P

        public ICollection<SiteReviews> Reviews { get; set; }

        public ICollection<SiteVotes> Votes { get; set; }

        public ICollection<ReportedSites> Reported_Sites { get; set; }
        #endregion
    }
}
