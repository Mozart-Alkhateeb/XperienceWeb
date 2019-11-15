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
            optionsBuilder.UseSqlServer("Server=.;Database=Xperience;User Id=sa;Password=P@ssw0rd");

            return new ApplicationDbContext(optionsBuilder.Options);
        }
    }
}
