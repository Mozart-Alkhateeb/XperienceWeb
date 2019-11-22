using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Xperience.Data.Entities
{
    public class Categories
    {
        [Key()]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }


        #region N.P

        public ICollection<Sites> Sites_category_id { get; set; }
        #endregion


    }
}
