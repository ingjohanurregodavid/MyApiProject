using Microsoft.EntityFrameworkCore;
using MyApiProject.API.Models;

namespace MyApiProject.API.Data
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { 
        
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderHistory> orderHistories { get; set; }
        public DbSet<OrderItem> orderItems { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            // Configuración de OrderItem
            modelBuilder.Entity<OrderItem>()
                .HasKey(oi => oi.Id);

            modelBuilder.Entity<OrderItem>()
                .HasOne(oi => oi.Order) // Relación con Order
                .WithMany(o => o.Items) // Una orden tiene muchos items
                .HasForeignKey(oi => oi.OrderId); // Llave foránea en OrderItem

            modelBuilder.Entity<OrderItem>()
                .HasOne(oi => oi.Product) // Relación con Product
                .WithMany() // Un producto puede estar en muchos OrderItems
                .HasForeignKey(oi => oi.ProductId); // Llave foránea en OrderItem

            // Configuración de OrderHistory
            modelBuilder.Entity<OrderHistory>()
                .HasKey(oh => oh.Id);

            modelBuilder.Entity<OrderHistory>()
                .HasOne(oh => oh.Order) // Relación con Order
                .WithMany() // Una orden puede tener muchos historiales
                .HasForeignKey(oh => oh.OrderId); // Llave foránea en OrderHistory
        }

    }
}
