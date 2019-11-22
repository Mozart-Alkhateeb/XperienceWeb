using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Xperience.Data.Entities
{
    public class Connections
    {
        [Key, Column(Order = 0)]
        public int Connector_id { get; set; }
        [Key, Column(Order = 1)]
        public int Connected_id { get; set; }

        [ForeignKey("Connector_id")]
        public Users Connectors { get; set; }

        [ForeignKey("Connected_id")]
        public Users Connected { get; set; }

    }
}
