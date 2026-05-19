using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CompanySystem.DAL
{
    public class AppDbContext : IdentityDbContext<IdentityUser>
    {
        public AppDbContext() : base()
        {

        }

        public AppDbContext(DbContextOptions options) : base(options) { }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
          if (!optionsBuilder.IsConfigured)
             {
               string connectionString = "Server=localhost\\SQLEXPRESS;Database=lab9;Trusted_Connection=True;TrustServerCertificate=True;";
               optionsBuilder.UseSqlServer(connectionString);
             }
        }
        public override int SaveChanges()
        {
            AuditLog();
            return base.SaveChanges();
        }

        private void AuditLog()
        {
            var dateTime= DateTime.UtcNow;
            foreach(var entry in ChangeTracker.Entries<IAuditEntity>())
            {
                if (entry.State == EntityState.Added)
                {
                    entry.Entity.CreatedAt = dateTime;
                }
                else if (entry.State == EntityState.Modified)
                {
                    entry.Entity.UpdatedAt = dateTime;
                }
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var CreatedAt = new DateTime(2026, 5, 11 );

            var _categories = new List<Category>()

            {
                new Category { Id = 1, Name = "Electronics", CreatedAt = CreatedAt },
                new Category { Id = 2, Name = "Clothes", CreatedAt = CreatedAt },
                new Category { Id = 3, Name = "Books", CreatedAt = CreatedAt },
                new Category { Id = 4, Name = "Home Appliances", CreatedAt = CreatedAt }
            };

            var _products = new List<Product>()
            {
                new Product { Id = 1, Title = "Laptop", Description = "Gaming Laptop", Price = 15000, Count = 5, ExpiryDate = new DateTime(2025, 12, 31), CategoryId = 1,CreatedAt= CreatedAt },
                new Product { Id = 2, Title = "Headphones", Description = "Wireless Headphones", Price = 500, Count = 20, ExpiryDate = new DateTime(2025, 6, 15), CategoryId = 1,CreatedAt= CreatedAt },
                new Product { Id = 3, Title = "Smartphone", Description = "Android Phone", Price = 8000, Count = 10, ExpiryDate = new DateTime(2025, 9, 20), CategoryId = 1,CreatedAt= CreatedAt },

                new Product { Id = 4, Title = "T-Shirt", Description = "Cotton T-Shirt", Price = 200, Count = 50, ExpiryDate = new DateTime(2026, 1, 10), CategoryId = 2,CreatedAt= CreatedAt },
                new Product { Id = 5, Title = "Jeans", Description = "Blue Jeans", Price = 600, Count = 25, ExpiryDate = new DateTime(2026, 3, 5), CategoryId = 2,CreatedAt= CreatedAt },

                new Product { Id = 6, Title = "C# Book", Description = "Learn C#", Price = 300, Count = 15, ExpiryDate = new DateTime(2025, 11, 1), CategoryId = 3,CreatedAt= CreatedAt },
                new Product { Id = 7, Title = "Algorithms Book", Description = "Data Structures", Price = 400, Count = 10, ExpiryDate = new DateTime(2025, 8, 25), CategoryId = 3,CreatedAt= CreatedAt },

                new Product { Id = 8, Title = "Microwave", Description = "800W Microwave", Price = 2500, Count = 7, ExpiryDate = new DateTime(2026, 2, 28), CategoryId = 4,CreatedAt= CreatedAt },
                new Product { Id = 9, Title = "Refrigerator", Description = "Double Door", Price = 12000, Count = 3, ExpiryDate = new DateTime(2026, 4, 15), CategoryId = 4,CreatedAt= CreatedAt },
                new Product { Id = 10, Title = "Washing Machine", Description = "Automatic", Price = 9000, Count = 4, ExpiryDate = new DateTime(2026, 5, 1), CategoryId = 4,CreatedAt= CreatedAt }
            };
            modelBuilder.Entity<Category>().HasData(_categories);
            modelBuilder.Entity<Product>().HasData(_products);

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
            base.OnModelCreating(modelBuilder);
        }
        public DbSet<Product> Products=> Set<Product>();
        public DbSet<Category> Categorys => Set<Category>();
    }
}
