using System;
using Microsoft.EntityFrameworkCore;
using Xperience.Data.Entities;

namespace Xperience.Data
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<SiteCategory> SiteCategories { get; set; }
        public DbSet<Site> Sites { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            //Here is where you configure how you want to deal with problems
            //such as cascading and the relation ship between your tables

            modelBuilder.Entity<Site>()
                .HasOne(q => q.SiteCategory)
                .WithMany(q => q.Sites)
                .OnDelete(DeleteBehavior.Restrict);//See here test out these, there are multiple behaviors regarding cascading
        }
    }
}
