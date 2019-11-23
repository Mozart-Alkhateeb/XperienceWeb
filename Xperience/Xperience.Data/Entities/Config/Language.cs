using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Xperience.Data.Entities.Users;

namespace Xperience.Data.Entities.Config
{
    public class Language:BaseEntityAutoKey
    {
        [Column(Order = 1), Required, MaxLength(250)]
        public string Name { get; set; }

        #region N.P

        public ICollection<UserLanguage> UserLanguages { get; set; }
        #endregion
    }
}
