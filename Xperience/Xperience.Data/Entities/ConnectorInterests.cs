using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Xperience.Data.Entities
{
   public class ConnectorInterests
    {
        [Key, Column(Order = 0)]
        public int Id { get; set; }
        [Key, Column(Order = 1)]
        public int Category_id { get; set; }

        #region F.K

        [ForeignKey("Id")]
        public Users Connector_interets_id { get; set; }

        [ForeignKey("Category_id")]
        public Categories Connector_interests_categories { get; set; }
        #endregion
    }
}
