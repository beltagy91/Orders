using Microsoft.EntityFrameworkCore;
using OrdersManager.Domain;

namespace OrdersManager.Data
{
    public class OrdersManagerDbContext : DbContext
    {
        public OrdersManagerDbContext()
        {
        }

        public OrdersManagerDbContext(DbContextOptions<OrdersManagerDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Customer> Customers { get; set; }  
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }


    }
}
