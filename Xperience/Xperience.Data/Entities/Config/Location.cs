using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Xperience.Data.Entities.Sites;
using Xperience.Data.Entities.Users;

namespace Xperience.Data.Entities.Config
{
    public class Location:BaseEntityAutoKey
    {
        [Column(Order = 1), Required]
        public string Name { get; set; }

        #region N.P

        public ICollection<ApplicationUser> ApplicationUsers{ get; set; }
        public ICollection<Site> Sites { get; set; }
        #endregion
    }
}
