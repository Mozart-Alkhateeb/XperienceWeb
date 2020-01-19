using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Xperience.Data.Entities.Config;
using Xperience.Data.Entities.Posts;
using Xperience.Data.Entities.Sites;
using Xperience.Data.Entities.Users;

namespace Xperience.Data
{
    public class ApplicationDbContext : IdentityDbContext<BaseUser, ApplicationRole, string>
    {
        #region Config

        public DbSet<Category> Categories { get; set; }
        public DbSet<Hashtag> Hashtags { get; set; }
        public DbSet<Language> Languages { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<Nationality> Nationalities { get; set; }
        public DbSet<Rating> Ratings { get; set; }
        public DbSet<Reaction> Reactions { get; set; }
        public DbSet<Religion> Religions { get; set; }
        #endregion

        #region Posts

        public DbSet<Comment> Comments { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<PostReaction> PostReactions { get; set; }
        public DbSet<ReportedPost> ReportedPosts { get; set; }
        public DbSet<PostHashtag> PostHashtags { get; set; }
        #endregion

        #region Sites

        public DbSet<ReportedSite> ReportedSites { get; set; }
        public DbSet<Site> Sites { get; set; }
        #endregion

        #region Users

     //   public DbSet<ApplicationUser> ApplicationUsers { get; set; }
        public DbSet<Block> Blocks { get; set; }
        public DbSet<Connection> Connections { get; set; }
        public DbSet<ConnectionRequest> ConnectionRequests { get; set; }
        public DbSet<ConnectorLocation> ConnectorLocations { get; set; }
        public DbSet<FollowedSite> FollowedSites { get; set; }
        public DbSet<FollowedUser> FollowedUsers { get; set; }
        public DbSet<ReportedUser> ReportedUsers { get; set; }
        public DbSet<SiteVote> SiteVotes { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<UserInterest> UserInterests { get; set; }
        public DbSet<UserLanguage> UserLanguages { get; set; }
        public DbSet<UserNationality> UserNationalities { get; set; }
        public DbSet<UserReview> UserReviews { get; set; }
        public DbSet<UserSiteReview> UserSiteReviews { get; set; }
        public DbSet<BaseUser> baseUsers;
        #endregion

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public ApplicationDbContext() : base()
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            #region Delete

            //Amena added delete PostHashtag
            modelBuilder.Entity<Post>()
               .HasMany(q => q.PostHashtags)
               .WithOne(q => q.Post)
               .OnDelete(DeleteBehavior.ClientCascade);

            //Amena added delete PostHashtag2
            modelBuilder.Entity<Hashtag>()
               .HasMany(q => q.PostHashtags)
               .WithOne(q => q.Hashtag)
               .OnDelete(DeleteBehavior.ClientCascade);

            // Delete PostReactions
            modelBuilder.Entity<Post>()
                .HasMany(q => q.PostReactions)
                .WithOne(q => q.Post)
                .OnDelete(DeleteBehavior.ClientCascade);

            // Delete PostReactions
            modelBuilder.Entity<ApplicationUser>()
                .HasMany(q => q.PostReactions)
                .WithOne(q => q.ApplicationUser)
                .OnDelete(DeleteBehavior.ClientCascade);

            // Delete ReviewedBy
            modelBuilder.Entity<UserReview>()
                .HasOne(q => q.Reviewed)
                .WithMany(q => q.ReviewedBy)
                .OnDelete(DeleteBehavior.ClientCascade);

            // Delete Rated
            modelBuilder.Entity<ApplicationUser>()
                .HasMany(q => q.RatedBy)
                .WithOne(q => q.Rated)
                .OnDelete(DeleteBehavior.ClientCascade);

            // Delete Reported
            modelBuilder.Entity<ApplicationUser>()
                .HasMany(q => q.ReportedBy)
                .WithOne(q => q.Reported)
                .OnDelete(DeleteBehavior.ClientCascade);

            //amena added 
            modelBuilder.Entity<Post>()
              .HasMany(q => q.ReportedPosts)
              .WithOne(q => q.Post)
              .OnDelete(DeleteBehavior.ClientCascade);

            //amena added Delete Posts
            modelBuilder.Entity<Site>()
              .HasMany(q => q.Posts)
              .WithOne(q => q.Site)
              .OnDelete(DeleteBehavior.ClientCascade);

            //amena added Delete Comments
            modelBuilder.Entity<Post>()
              .HasMany(q => q.Comments)
              .WithOne(q => q.Post)
              .OnDelete(DeleteBehavior.ClientCascade);

            // Delete UserNationalities
            modelBuilder.Entity<ApplicationUser>()
                .HasMany(q => q.UserNationalities)
                .WithOne(q => q.ApplicationUser)
                .OnDelete(DeleteBehavior.ClientCascade);



            // Delete UserLanguages
            modelBuilder.Entity<ApplicationUser>()
                .HasMany(q => q.UserLanguages)
                .WithOne(q => q.ApplicationUser)
                .OnDelete(DeleteBehavior.ClientCascade);

            // Delete Connections
            modelBuilder.Entity<Connection>()
                .HasOne(q => q.ApplicationUser)
                .WithMany(q => q.ConnectedTo)
                .OnDelete(DeleteBehavior.ClientCascade);

            modelBuilder.Entity<Connection>()
                .HasOne(q => q.Connected)
                .WithMany(q => q.Connections)
                .OnDelete(DeleteBehavior.ClientCascade);

            // Delete Tags
            modelBuilder.Entity<Tag>()
                .HasOne(q => q.ApplicationUser)
                .WithMany(q => q.Tags)
                .OnDelete(DeleteBehavior.ClientCascade);

            modelBuilder.Entity<Tag>()
                .HasOne(q => q.Tagged)
                .WithMany(q => q.TaggedBy)
                .OnDelete(DeleteBehavior.ClientCascade);



            // Delete Blocks
            modelBuilder.Entity<ApplicationUser>()
                .HasMany(q => q.Blocks)
                .WithOne(q => q.ApplicationUser)
                .OnDelete(DeleteBehavior.ClientCascade);

            modelBuilder.Entity<ApplicationUser>()
                .HasMany(q => q.BlockedBy)
                .WithOne(q => q.Blocked)
                .OnDelete(DeleteBehavior.ClientCascade);

            // Delete FollowedUsers
            modelBuilder.Entity<ApplicationUser>()
                .HasMany(q => q.FollowedUsers)
                .WithOne(q => q.ApplicationUser)
                .OnDelete(DeleteBehavior.ClientCascade);

            modelBuilder.Entity<ApplicationUser>()
                .HasMany(q => q.FollowedBy)
                .WithOne(q => q.Follower)
                .OnDelete(DeleteBehavior.ClientCascade);

            // Delete ConnectionRequests
            modelBuilder.Entity<ApplicationUser>()
                .HasMany(q => q.SentConnectionRequests)
                .WithOne(q => q.ApplicationUser)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<ApplicationUser>()
                .HasMany(q => q.ReceivedConnectionRequests)
                .WithOne(q => q.Receiver)
                .OnDelete(DeleteBehavior.ClientCascade);

            //Delete FollowedSites
            modelBuilder.Entity<ApplicationUser>()
                .HasMany(q => q.FollowedSites)
                .WithOne(q => q.ApplicationUser)
                .OnDelete(DeleteBehavior.ClientCascade);

            //amena added Delete Followed Site
            modelBuilder.Entity<Site>()
                .HasMany(q => q.FollowedSites)
                .WithOne(q => q.Site)
                .OnDelete(DeleteBehavior.ClientCascade);

            //Delete UserInterests
            modelBuilder.Entity<ApplicationUser>()
                .HasMany(q => q.UserInterests)
                .WithOne(q => q.ApplicationUser)
                .OnDelete(DeleteBehavior.ClientCascade);

            //Delete ConnectorLocations
            modelBuilder.Entity<ApplicationUser>()
                .HasMany(q => q.ConnectorLocations)
                .WithOne(q => q.ApplicationUser)
                .OnDelete(DeleteBehavior.ClientCascade);
            #endregion

            #region Set Null

            // Keep Ratings
            modelBuilder.Entity<ApplicationUser>()
                .HasMany(q => q.Ratings)
                .WithOne(q => q.ApplicationUser)
                .OnDelete(DeleteBehavior.ClientSetNull);

            //amena added Keep Posts

            modelBuilder.Entity<ApplicationUser>()
             .HasMany(q => q.Posts)
             .WithOne(q => q.ApplicationUser)
             .OnDelete(DeleteBehavior.ClientSetNull);

            //amena added Keep Comments

            modelBuilder.Entity<ApplicationUser>()
             .HasMany(q => q.Comments)
             .WithOne(q => q.ApplicationUser)
             .OnDelete(DeleteBehavior.ClientSetNull);

            //amena added Keep Connector Locations

            modelBuilder.Entity<Location>()
             .HasMany(q => q.ConnectorLocations)
             .WithOne(q => q.Location)
             .OnDelete(DeleteBehavior.ClientSetNull);

            // Keep UserReviews
            modelBuilder.Entity<ApplicationUser>()
                .HasMany(q => q.UserReviews)
                .WithOne(q => q.ApplicationUser)
                .OnDelete(DeleteBehavior.ClientSetNull);

            // Keep ReportedUsers
            modelBuilder.Entity<ApplicationUser>()
                .HasMany(q => q.ReportedUsers)
                .WithOne(q => q.ApplicationUser)
                .OnDelete(DeleteBehavior.ClientSetNull);

            // Keep UserSiteReviews
            modelBuilder.Entity<ApplicationUser>()
                .HasMany(q => q.UserSiteReviews)
                .WithOne(q => q.ApplicationUser)
                .OnDelete(DeleteBehavior.ClientSetNull);

            // Keep SiteVotes
            modelBuilder.Entity<ApplicationUser>()
                .HasMany(q => q.SiteVotes)
                .WithOne(q => q.ApplicationUser)
                .OnDelete(DeleteBehavior.ClientSetNull);

            // Keep ReportedSites
            modelBuilder.Entity<ApplicationUser>()
                .HasMany(q => q.ReportedSites)
                .WithOne(q => q.ApplicationUser)
                .OnDelete(DeleteBehavior.ClientSetNull);

            // Keep ReportedPosts
            modelBuilder.Entity<ApplicationUser>()
                .HasMany(q => q.ReportedPosts)
                .WithOne(q => q.ApplicationUser)
                .OnDelete(DeleteBehavior.ClientSetNull);

            //amena added Keep Posts
           /* modelBuilder.Entity<Post>()
             .HasMany(q => q.PostHashtags)
             .WithOne(q => q.Post)
             .OnDelete(DeleteBehavior.ClientSetNull);*/


            //amena added delete tags keep post
            modelBuilder.Entity<Tag>()
              .HasOne(q => q.Post)
              .WithMany(q => q.Tags)
              .OnDelete(DeleteBehavior.ClientSetNull);


            #endregion

            #region Restrict Delete

            modelBuilder.Entity<Category>()
                .HasMany(q => q.Sites)
                .WithOne(q => q.Category)
                .OnDelete(DeleteBehavior.Restrict);



            modelBuilder.Entity<Category>()
                .HasMany(q => q.UserInterests)
                .WithOne(q => q.Category)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Religion>()
                .HasMany(q => q.ApplicationUsers)
                .WithOne(q => q.Religion)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Language>()
                .HasMany(q => q.UserLanguages)
                .WithOne(q => q.Language)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Location>()
                .HasMany(q => q.Sites)
                .WithOne(q => q.Location)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Location>()
                .HasMany(q => q.ApplicationUsers)
                .WithOne(q => q.Location)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Nationality>()
                .HasMany(q => q.UserNationalities)
                .WithOne(q => q.Nationality)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Reaction>()
                .HasMany(q => q.PostReactions)
                .WithOne(q => q.Reaction)
                .OnDelete(DeleteBehavior.Restrict);


            #endregion

            #region Composite F.K

            modelBuilder.Entity<Rating>()
                .HasKey(q => new { q.ApplicationUserId, q.RatedId });

            modelBuilder.Entity<PostReaction>()
                .HasKey(q => new { q.PostId, q.ApplicationUserId });

            modelBuilder.Entity<Block>()
                .HasKey(q => new { q.ApplicationUserId, q.BlockedId });

            modelBuilder.Entity<Connection>()
                .HasKey(q => new { q.ApplicationUserId, q.ConnectedId });

            modelBuilder.Entity<ConnectionRequest>()
                .HasKey(q => new { q.ApplicationUserId, q.ReceiverId });

            modelBuilder.Entity<ConnectorLocation>()
                .HasKey(q => new { q.ApplicationUserId, q.LocationId });


            modelBuilder.Entity<FollowedSite>()
                .HasKey(q => new { q.ApplicationUserId, q.SiteId });

            modelBuilder.Entity<FollowedUser>()
                .HasKey(q => new { q.ApplicationUserId, q.FollowerId });

            modelBuilder.Entity<UserInterest>()
                .HasKey(q => new { q.ApplicationUserId, q.CategoryId });

            modelBuilder.Entity<UserLanguage>()
                .HasKey(q => new { q.ApplicationUserId, q.LanguageId });

            modelBuilder.Entity<UserNationality>()
                .HasKey(q => new { q.ApplicationUserId, q.NationalityId });

            modelBuilder.Entity<PostHashtag>()
             .HasKey(q => new { q.PostId, q.HashtagId });

            #endregion
        }

    }
}
