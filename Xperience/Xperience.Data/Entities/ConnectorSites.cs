using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Xperience.Data.Entities
{
    public class ConnectorSites
    {
        [Key, Column(Order = 0)]
        public int Id { get; set; }

        [Key, Column(Order = 1)]
        public int Location_id { get; set; }
        #region F.K

        [ForeignKey ("Id")]
        public Users Connector_sites_id { get; set; }

        [ForeignKey("Location_id")]
        public Locations Location_connector_sites { get; set; }

        #endregion
    }
}
