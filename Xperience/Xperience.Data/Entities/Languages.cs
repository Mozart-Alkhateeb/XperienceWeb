using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Xperience.Data.Entities
{
    public class Languages
    {
        [Key()]
        public int User_id { get; set; }
        [Required]
        public string Language { get; set; }

        #region F.K

        [ForeignKey("User_id")]
        public Users Languages_user_id { get; set; }


        #endregion


    }
}
