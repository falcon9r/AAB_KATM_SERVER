using Microsoft.AspNetCore.Hosting.Server;
using Microsoft.EntityFrameworkCore;

namespace AAB_KATM_SERVER.Configuration
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext() 
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string connectionString = "Server = sql-server; Database = aab; User Id = SA; Password = RPSsql12345;TrustServerCertificate=true";
            optionsBuilder.UseSqlServer(connectionString);
            optionsBuilder.LogTo(Console.WriteLine);
        }
    }
}
