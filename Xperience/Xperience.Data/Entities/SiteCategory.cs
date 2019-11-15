using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Xperience.Data.Entities
{
    public class SiteCategory
    {
        [Key()]
        public int Id { get; set; }
        [Required]
        [MaxLength(100)]
        public string Description { get; set; }

        #region N.P

        public ICollection<Site> Sites { get; set; }
        #endregion
    }
}
