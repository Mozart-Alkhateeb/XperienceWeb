using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Xperience.Data.Entities
{
    public class Site
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Longitude { get; set; }
        public string Latitude { get; set; }

        #region F.K

        public int SiteCategoryId { get; set; }
        [ForeignKey("SiteCategoryId")]
        public SiteCategory SiteCategory { get; set; }
        #endregion
    }
}
