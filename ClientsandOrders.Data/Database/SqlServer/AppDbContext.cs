using ClientsandOrders.Data.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace ClientsandOrders.Data.Database.SqlServer
{
    public class AppDbContext : DbContext 
    {
        public DbSet<Order> Orders { get; set; }
        public DbSet<Client> Clients { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Client>()
                .HasMany(c => c.OrdersList)
                .WithOne(o => o.Client)
                .HasForeignKey(o => o.Id);
            modelBuilder.Entity<Order>()
                .HasOne(o => o.Client)
                .WithMany(c => c.OrdersList)
                .HasForeignKey(o => o.ClientId)
                .OnDelete(DeleteBehavior.Cascade);
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            IConfiguration config = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .Build();

            string? connectionString = config
                .GetConnectionString("ConnectionString");

            optionsBuilder
                .UseSqlServer(connectionString);
        }

        
    }
}
