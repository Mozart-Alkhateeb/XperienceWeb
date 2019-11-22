using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Xperience.Data.Entities
{
   public class ConnectorInfo
    {
        [Key()]
        public int Id { get; set; }

        [Required]
        public string Info { get; set; }


        [ForeignKey("id")]
        public Users Connector_info_id { get; set; }



    }
}
