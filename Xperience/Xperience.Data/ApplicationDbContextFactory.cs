using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Xperience.Data
{
    public class ApplicationDbContextFactory : IDesignTimeDbContextFactory<ApplicationDbContext>
    {
        public ApplicationDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
            // this Connection string is not used to serve content to your users, this is here just to create table and the database
            optionsBuilder.UseSqlServer("Server=.;Database=XperienceDB;User Id=sa;Password=sql123");

            return new ApplicationDbContext(optionsBuilder.Options);
        }
    }
}
