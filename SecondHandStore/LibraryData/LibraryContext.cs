
using Entities;
using Microsoft.EntityFrameworkCore;

namespace LibraryData
{
    public class LibraryContext : DbContext
    {
        public DbSet<UserModel> Users { get; set; }
        public DbSet<ProductModel> Products { get; set; }

        public LibraryContext(DbContextOptions<LibraryContext> options) : base(options)
        {}
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            var userBdayType = modelBuilder.Entity<UserModel>();
            userBdayType.Property(u => u.BirthDate).HasColumnType("smalldatetime");
            var productDateType = modelBuilder.Entity<ProductModel>();
            productDateType.Property(p => p.DateUpload).HasColumnType("smalldatetime");
            modelBuilder.Entity<ProductModel>().Property(p => p.Price).HasPrecision(18, 2); 
        }
         
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseLazyLoadingProxies();
            optionsBuilder.EnableSensitiveDataLogging();
        }

    }
}
