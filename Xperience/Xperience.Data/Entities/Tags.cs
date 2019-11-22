using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
namespace Xperience.Data.Entities
{
    public class Tags
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int Tagger_id { get; set; }
        [Required]
        public int Tagged_id { get; set; }
        [Required]
        public int Post_id { get; set; }

        #region F.K
        [ForeignKey("Tagger_id")]
        public  Users Tags_tagger { get; set; }

        [ForeignKey("Tagged_id")]
        public  Users Tags_tagged { get; set; }

        [ForeignKey("Post_id")]
        public Posts Tags_post { get; set; }

        #endregion


    }
}
