using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System.IO;
using UserManagementAPI.Models;
// Ensure the correct namespace for ApplicationDbContext is imported
using UserManagementAPI.Data;
namespace UserManagementAPI.Data
{
    // Ensure ApplicationDbContext is defined in this file or imported from another file in the correct namespace
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        // Define your DbSets here, for example:
        public DbSet<User> Users { get; set; }
    }

    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<ApplicationDbContext>
    {
        public ApplicationDbContext CreateDbContext(string[] args)
        {
            // Build configuration by reading appsettings.json.
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            var builder = new DbContextOptionsBuilder<ApplicationDbContext>();

            // Retrieve the connection string from the configuration.
            var connectionString = configuration.GetConnectionString("DefaultConnection");

            // Configure the DbContext to use PostgreSQL.
            builder.UseNpgsql(connectionString);

            return new ApplicationDbContext(builder.Options);
        }
    }
}