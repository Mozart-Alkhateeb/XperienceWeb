using System;
using Microsoft.EntityFrameworkCore;
using Xperience.Data.Entities;

namespace Xperience.Data
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Admin> Admins { get; set; }
        public DbSet<Users> Users{ get; set; }

        public DbSet<Blocks> Blocks { get; set; }
        public DbSet<Categories> Categories { get; set; }

        public DbSet<Comments> Comments { get; set; }
        public DbSet<ConnectionRequests> Connection_Requests { get; set; }

        public DbSet<Connections> Connections { get; set; }
        public DbSet<ConnectorInfo> ConnectorInfos { get; set; }

        public DbSet<ConnectorInterests> ConnectorInterests { get; set; }
        public DbSet<ConnectorSites> Connector_Sites { get; set; }


        public DbSet<FollowedSites> FollowedSites { get; set; }
        public DbSet<FollowedUsers> FollowedUsers { get; set; }


        public DbSet<Hashtags> Hashtags { get; set; }
        public DbSet<Languages> Languages { get; set; }


        public DbSet<Locations> Locations { get; set; }
        public DbSet<Nationalities> Nationalities { get; set; }



        public DbSet<Posts> Posts { get; set; }
        public DbSet<Ratings> Ratings { get; set; }


        public DbSet<ReactionIcons> Reaction_Icons { get; set; }
        public DbSet<Reactions> Reactions { get; set; }


        public DbSet<Religion> Religions { get; set; }
        public DbSet<ReportedPosts> ReportedPosts { get; set; }


        public DbSet<ReportedSites>Reported_Sites  { get; set; }
        public DbSet<ReportedUsers> ReportedUsers { get; set; }


        public DbSet<SiteReviews> Site_Reviews { get; set; }
        public DbSet<SiteVotes> Site_Votes { get; set; }


        public DbSet<Sites> Sites { get; set; }
        public DbSet<Tags> Tags { get; set; }


        public DbSet<UserReviews> User_Reviews { get; set; }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            //Here is where you configure how you want to deal with problems
            //such as cascading and the relation ship between your tables

            //NOTE: the tables involved are: Users,reporedsites,userreviews,siteVotes,connections,sites,nationalities

            //the comments starting with -- refer to my quests

            //---i didnt add the two below because i dont want to delete a user if the religion or locations are deleted.. am i right?

            /*modelBuilder.Entity<Users>()
                .HasOne(q => q.Religion)
                .WithMany(q => q.Users)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Users>()
                .HasOne(q => q.Location)
                .WithMany(q => q.Users)
                .OnDelete(DeleteBehavior.Restrict);*/

            modelBuilder.Entity<Connections>()
       .HasKey(c => new { c.Connector_id, c.Connected_id});

            modelBuilder.Entity<SiteVotes>()
    .HasKey(c => new { c.Site_id, c.User_id });

            modelBuilder.Entity<ReportedSites>()
 .HasKey(c => new { c.Reporter_id, c.Reported_id });

            modelBuilder.Entity<Blocks>()
.HasKey(c => new { c.Blocked_id, c.Blocker_id });

            modelBuilder.Entity<ConnectionRequests>()
.HasKey(c => new { c.Connected_id, c.Connector_id });

            modelBuilder.Entity<ConnectorInterests>()
.HasKey(c => new { c.Id, c.Category_id });
            modelBuilder.Entity<ConnectorSites>()
.HasKey(c => new { c.Id, c.Location_id });
            modelBuilder.Entity<FollowedSites>()
.HasKey(c => new { c.Follower_id, c.Followed_id });

            modelBuilder.Entity<FollowedUsers>()
.HasKey(c => new { c.Followed_id, c.Follower_id });

            modelBuilder.Entity<Ratings>()
.HasKey(c => new { c.Rater_id, c.Rated_id });


            modelBuilder.Entity<Reactions>()
.HasKey(c => new { c.User_id, c.Post_id });


            modelBuilder.Entity<ReportedPosts>()
.HasKey(c => new { c.Reporter_id, c.Post_id });


            modelBuilder.Entity<ReportedUsers>()
.HasKey(c => new { c.Reporter_id, c.Reported_id });

            modelBuilder.Entity<SiteVotes>()
.HasKey(c => new { c.User_id, c.Site_id });

            //---this will allow a review to be deleted whenever a site or user is deleted, right?
            modelBuilder.Entity<SiteReviews>()
                .HasOne(q => q.Sites)
                .WithMany(q => q.Reviews)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<SiteReviews>()
                .HasOne(q => q.Users)
                .WithMany(q => q.Reviews)
                .OnDelete(DeleteBehavior.Restrict);

            //---this will remove the vote if a site or a user is deleted, right?(Composite PK)

            modelBuilder.Entity<SiteVotes>()
            .HasOne(q => q.Sites)
            .WithMany(q => q.Votes)
            .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<SiteVotes>()
                .HasOne(q => q.Users)
                .WithMany(q => q.Votes)
                .OnDelete(DeleteBehavior.Restrict);

            //---this indicates whenever a user is removed the connection will be removed too , right?(Composite PK)

            modelBuilder.Entity<Connections>()
                          .HasOne(q => q.Connected)
                          .WithMany(q => q.UsersConnected)
                          .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Connections>()
                     .HasOne(q => q.Connectors)
                     .WithMany(q => q.UsersConnectors)
                     .OnDelete(DeleteBehavior.Restrict);


            //---a report record must be gone whenever one of the two is deleted?
            modelBuilder.Entity<ReportedSites>()
                    .HasOne(q => q.Reported_sites_user)
                    .WithMany(q => q.ReporterUser)
                    .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<ReportedSites>()
                    .HasOne(q => q.Reported_sites_site)
                    .WithMany(q => q.Reported_Sites)
                    .OnDelete(DeleteBehavior.Restrict);

            //--- a review record must be gone if one the two two users is deleted

            modelBuilder.Entity<UserReviews>()
                    .HasOne(q => q.User_reviews_user1)
                    .WithMany(q => q.Reviewer)
                    .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<UserReviews>()
                    .HasOne(q => q.User_Reviews_user2)
                    .WithMany(q => q.Reviewed)
                    .OnDelete(DeleteBehavior.Restrict);


            //---delete record whenever user is deleted

            modelBuilder.Entity<Nationalities>()
                    .HasOne(q => q.Nationalities_user_id)
                    .WithMany(q => q.Nationalities)
                    .OnDelete(DeleteBehavior.Restrict);

            //---the update cascade is done by default to all foreign keys with no need to add any methods?

            //See here test out these, there are multiple behaviors regarding cascading
        }
    }
}
