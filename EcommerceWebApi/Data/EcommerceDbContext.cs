using EcommerceWebApi.Models;
using Microsoft.EntityFrameworkCore;

namespace EcommerceWebApi.Data
{
    public class EcommerceDbContext(DbContextOptions<EcommerceDbContext> options) : DbContext(options)
    {

        public DbSet<Account> Accounts { get; set; }
        public DbSet<AccountChatRoom> AccountChatRooms { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<ChatRoom> ChatRooms { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Like> Likes { get; set; }
        public DbSet<CustomerNotification> CustomerNotifications { get; set; }
        public DbSet<CustomerType> CustomerTypes { get; set; }
        public DbSet<CustomerTypeSaleEvent> CustomerTypeSaleEvents { get; set; }
        public DbSet<DetailOrder> DetailOrders { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<Notification> Notifications { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductImage> ProductImages { get; set; }
        public DbSet<ProductSaleEvent> ProductSaleEvents { get; set; }
        public DbSet<ProductType> ProductTypes { get; set; }
        public DbSet<Rating> Ratings { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<SaleEvent> SaleEvents { get; set; }
        public DbSet<Shop> Shops { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // m-to-m relationship
            modelBuilder.Entity<Account>()
               .HasMany(e => e.ChatRooms)
               .WithMany(e => e.Accounts)
               .UsingEntity<AccountChatRoom>();

            modelBuilder.Entity<Customer>()
               .HasMany(e => e.Notifications)
               .WithMany(e => e.Customers)
               .UsingEntity<CustomerNotification>();

            modelBuilder.Entity<CustomerType>()
               .HasMany(e => e.SaleEvents)
               .WithMany(e => e.CustomerTypes)
               .UsingEntity<CustomerTypeSaleEvent>();

            modelBuilder.Entity<Product>()
               .HasMany(e => e.SaleEvents)
               .WithMany(e => e.Products)
               .UsingEntity<ProductSaleEvent>();

            // enum column
            modelBuilder.Entity<Order>()
              .Property(o => o.Status)
              .HasConversion<string>();

            modelBuilder.Entity<Order>()
              .Property(o => o.PaymentStatus)
              .HasConversion<string>();

            // set delete behavior
            modelBuilder.Entity<Order>()
               .HasOne(o => o.Customer)
               .WithMany(c => c.Orders)
               .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Like>()
               .HasOne(l => l.Product)
               .WithMany(l => l.Likes)
               .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<DetailOrder>()
               .HasOne(d => d.Product)
               .WithMany(d => d.DetailOrders)
               .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Rating>()
              .HasOne(r => r.Order)
              .WithMany(r => r.Ratings)
              .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Rating>()
              .HasOne(r => r.Product)
              .WithMany(r => r.Ratings)
              .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.SeedAllData();
        }
    }
}
