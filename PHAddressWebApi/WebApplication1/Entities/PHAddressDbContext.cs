using Microsoft.EntityFrameworkCore;

namespace PHAddressWebApi.Entities
{
    public class PHAddressDbContext : DbContext
    {
        public DbSet<Region> Regions { get; set; }
        public DbSet<Province> Provinces { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Barangay> Barangays { get; set; }

        public PHAddressDbContext(DbContextOptions options)
            : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Name=Default");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Region>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.PsgcCode).IsRequired().HasMaxLength(50);
                entity.Property(e => e.RegionName).IsRequired().HasMaxLength(100);
                entity.Property(e => e.RegionCode).IsRequired().HasMaxLength(10);
                entity.HasIndex(e => e.PsgcCode).HasDatabaseName("IX_Region_PsgcCode");
            });

            modelBuilder.Entity<Province>(entity =>
            {
                entity.HasKey(e => e.ProvinceCode);
                entity.Property(e => e.ProvinceCode).IsRequired().HasMaxLength(50);
                entity.Property(e => e.ProvinceName).IsRequired().HasMaxLength(100);
                entity.Property(e => e.PsgcCode).IsRequired().HasMaxLength(50);
                entity.Property(e => e.RegionCode).IsRequired().HasMaxLength(10);
                entity.HasIndex(e => e.ProvinceCode).HasDatabaseName("IX_Province_ProvinceCode");
            });

            modelBuilder.Entity<City>(entity =>
            {
                entity.HasKey(e => e.CityCode);
                entity.Property(e => e.CityCode).IsRequired().HasMaxLength(50);
                entity.Property(e => e.CityName).IsRequired().HasMaxLength(100);
                entity.Property(e => e.ProvinceCode).IsRequired().HasMaxLength(50);
                entity.Property(e => e.PsgcCode).IsRequired().HasMaxLength(50);
                entity.Property(e => e.RegionDesc).IsRequired().HasMaxLength(100);
                entity.HasIndex(e => e.CityCode).HasDatabaseName("IX_City_CityCode");
            });

            modelBuilder.Entity<Barangay>(entity =>
            {
                entity.HasKey(e => e.BrgyCode);
                entity.Property(e => e.BrgyCode).IsRequired().HasMaxLength(50);
                entity.Property(e => e.CityCode).IsRequired().HasMaxLength(50);
                entity.Property(e => e.BrgyName).IsRequired().HasMaxLength(50);
                entity.Property(e => e.ProvinceCode).IsRequired().HasMaxLength(50);
                entity.Property(e => e.RegionCode).IsRequired().HasMaxLength(50);
                entity.HasIndex(e => e.BrgyCode).HasDatabaseName("IX_Barangay_BrgyCode");
            });
        }
    }
}
