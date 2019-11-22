using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Xperience.Data.Entities
{
    public class Users
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Username { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }
        public string Biography { get; set; }
        public string Phone_number { get; set; }
        public string Profile_pic { get; set; }
        public bool Connector_status { get; set; }
        public int Age { get; set; }
        public string Gender { get; set; }
        [Required]
        public string Password { get; set; }


        #region F.K

        public int Location_id { get; set; }
        
        [ForeignKey("Location_id")]
        public Locations Location{ get; set; }

        public int Religion_id { get; set; }

        [ForeignKey("Religion_id")]
        public Religion Religion { get; set; }


        #endregion

        #region N.P

        public ICollection<Nationalities> Nationalities { get; set; }

        public ICollection<SiteReviews> Reviews { get; set; }

        public ICollection<SiteVotes> Votes { get; set; }

        public ICollection<Connections> UsersConnected { get; set; }

        public ICollection<Connections> UsersConnectors { get; set; }

        public ICollection<ReportedSites> ReporterUser { get; set; }

        public ICollection<UserReviews> Reviewer { get; set; }

        public ICollection<UserReviews> Reviewed { get; set; }

        #endregion
    }
}
