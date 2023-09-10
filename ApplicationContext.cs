using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;

namespace _001_MSSQl
{
    public class ApplicationContext : DbContext
    {


        public DbSet<Users> Users { get; set; }

        public ApplicationContext() : base(GetDbContextOptions())
        {
            Database.EnsureCreated();
        }

        private static DbContextOptions<ApplicationContext> GetDbContextOptions()
        {
            var builder = new SqlConnectionStringBuilder
            {
                DataSource = "DESKTOP-CL9R2P4",
                InitialCatalog = "001_example",
                IntegratedSecurity = true,
                TrustServerCertificate = true,
               
            };

            var optionsBuilder = new DbContextOptionsBuilder<ApplicationContext>();
            optionsBuilder.UseSqlServer(builder.ConnectionString);

            return optionsBuilder.Options;
        }


    }
}
