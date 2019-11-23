using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Xperience.Data.Entities.Config;
using Xperience.Data.Entities.Posts;
using Xperience.Data.Entities.Sites;

namespace Xperience.Data.Entities.Users
{
    public class ApplicationUser
    {
        public string Name { get; set; }
        public string Biography { get; set; }
        public string ProfilePicture { get; set; }
        public bool ConnectorStatus { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Gender { get; set; }
        [Required]
        public string Info { get; set; }

        #region F.K

        public string Id { get; set; }
        [Key, Column(Order = 0), ForeignKey("Id")]
        public BaseUser BaseUser { get; set; }

        public int LocationId { get; set; }
        [ForeignKey("LocationId")]
        public Location Location { get; set; }

        public int ReligionId { get; set; }
        [ForeignKey("ReligionId")]
        public Religion Religion { get; set; }
        #endregion

        #region N.P

        public ICollection<UserNationality> UserNationalities { get; set; }
        public ICollection<UserLanguage> UserLanguages { get; set; }
        public ICollection<UserSiteReview> UserSiteReviews { get; set; }
        public ICollection<SiteVote> SiteVotes { get; set; }
        public ICollection<ReportedSite> ReportedSites { get; set; }
        public ICollection<ReportedPost> ReportedPosts { get; set; }
        public ICollection<FollowedSite> FollowedSites { get; set; }
        public ICollection<UserInterest> UserInterests { get; set; }
        public ICollection<ConnectorLocation> ConnectorLocations { get; set; }
        public ICollection<PostReaction> PostReactions { get; set; }

        public ICollection<Connection> ConnectedTo { get; set; }
        public ICollection<Connection> Connections { get; set; }

        public ICollection<UserReview> UserReviews { get; set; }
        public ICollection<UserReview> ReviewedBy { get; set; }

        public ICollection<Block> Blocks { get; set; }
        public ICollection<Block> BlockedBy { get; set; }

        public ICollection<FollowedUser> FollowedUsers { get; set; }
        public ICollection<FollowedUser> FollowedBy { get; set; }

        public ICollection<ConnectionRequest> SentConnectionRequests { get; set; }
        public ICollection<ConnectionRequest> ReceivedConnectionRequests { get; set; }

        public ICollection<ReportedUser> ReportedUsers { get; set; }
        public ICollection<ReportedUser> ReportedBy { get; set; }

        public ICollection<Rating> Ratings { get; set; }
        public ICollection<Rating> RatedBy { get; set; }

        public ICollection<Tag> Tags { get; set; }
        public ICollection<Tag> TaggedBy { get; set; }
        #endregion
    }
}
