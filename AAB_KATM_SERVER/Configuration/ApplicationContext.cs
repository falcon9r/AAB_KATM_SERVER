using AAB_KATM_SERVER.Configuration.Database;
using AAB_KATM_SERVER.Entities;
using Microsoft.AspNetCore.Hosting.Server;
using Microsoft.EntityFrameworkCore;

namespace AAB_KATM_SERVER.Configuration
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Client> Clients { get; set; }

        public ApplicationContext() 
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string connectionString = Environment.GetEnvironmentVariable("DB_CONN");
            optionsBuilder.UseSqlServer(connectionString);
            optionsBuilder.LogTo(Console.WriteLine);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ClientConfiguration());
        }
    }
}
