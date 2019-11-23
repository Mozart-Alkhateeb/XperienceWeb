using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Xperience.Data.Entities.Config;
using Xperience.Data.Entities.Posts;
using Xperience.Data.Entities.Users;

namespace Xperience.Data.Entities.Sites
{
    public class Site : BaseEntityAutoKey
    {
        [Column(Order = 1)]
        [Required]
        public int Name { get; set; }

        [Column(Order = 2)]
        [Required]
        public float Latitude  { get; set; }

        [Column(Order = 3)]
        [Required]
        public float Longitude { get; set; }

        #region F.K
        [Column(Order = 4)]
        [Required]
        public int CategoryId { get; set; }
        [ForeignKey("CategoryId")]
        public Category Category { get; set; }

        [Column(Order = 5)]
        [Required]
        public int LocationId { get; set; }
        [ForeignKey("LocationId")]
        public Location Location { get; set; }

        #endregion

        #region N.P

        public ICollection<UserSiteReview> UserSiteReviews { get; set; }
        public ICollection<SiteVote> SiteVotes { get; set; }
        public ICollection<ReportedSite> ReportedSites { get; set; }

        public ICollection<FollowedSite> FollowedSites { get; set; }
        public ICollection<Post> Posts { get; set; }
        #endregion
    }
}
