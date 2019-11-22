using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Xperience.Data.Entities
{
   public class ReportedUsers
    {
        [Key, Column(Order = 0)]
        public int Reported_id { get; set; }

        [Key, Column(Order = 1)]
        public int Reporter_id { get; set; }

        #region F.K

        [ForeignKey("Reporter_id")]
        public Users Reporter { get; set; }

        [ForeignKey("Reported_id")]
        public Users Reported { get; set; }

        #endregion


    }
}
