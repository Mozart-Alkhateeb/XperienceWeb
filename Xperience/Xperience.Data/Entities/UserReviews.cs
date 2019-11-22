using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Xperience.Data.Entities
{
    public class UserReviews
    {
        [Key()]
        public int Id { get; set; }
        
        [Required]
        public int Reviewer_id { get; set; }
        [Required]
        public int Reviewed_id { get; set; }

        [Required]
        public string Review { get; set; }
        [Required]

        public DateTime Time { get; set; }

        #region F.K

        [ForeignKey("Reviewer_id")]
        public Users User_reviews_user1 { get; set; }

        [ForeignKey("Reviewed_id")]
        public Users User_Reviews_user2 { get; set; }

        #endregion

    }
}
