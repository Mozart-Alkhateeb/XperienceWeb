using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Xperience.Data.Entities
{
    public class Locations
    {
        [Key()]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }

        #region N.P

        public ICollection<Users> Users{ get; set; }
        #endregion

        #region N.P

        public ICollection<Sites> Sites { get; set; }
        #endregion



    }
}
