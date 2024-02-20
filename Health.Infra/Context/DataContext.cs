using Health.Domain.Entities;
using Microsoft.Extensions.Configuration;

namespace Health.Infra.Context;

using Microsoft.EntityFrameworkCore;
public class DataContext: DbContext
{
  protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
   {
       var config = new ConfigurationBuilder()
           .SetBasePath(Directory.GetCurrentDirectory())
           .AddJsonFile(@"C:\Users\Felipe\RiderProjects\Health\Health.App\appsettings.json")
           .Build();
       var connection = config.GetConnectionString("WebApiDatabase");
       optionsBuilder.UseMySql(connection, ServerVersion.AutoDetect(connection));
   }
    
    public DbSet<User> Users { get; set; }
}