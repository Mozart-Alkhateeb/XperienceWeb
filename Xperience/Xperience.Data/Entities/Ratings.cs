using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
namespace Xperience.Data.Entities
{
    public class Ratings
    {


        [Key, Column(Order = 0)]
        public int Rater_id { get; set; }

        [Key, Column(Order = 1)]
        public int Rated_id { get; set; }

        public float Rating { get; set; }


        [ForeignKey("Rater_id")]
        public Users Rater_user { get; set; }

        [ForeignKey("Rated_id")]
        public  Users Rated_user { get; set; }


    }
}
