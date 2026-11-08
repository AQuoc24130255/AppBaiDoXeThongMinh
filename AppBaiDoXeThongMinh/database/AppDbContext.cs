using AppBaiDoXeThongMinh.Models;
using Microsoft.EntityFrameworkCore;

namespace AppBaiDoXeThongMinh.database;
/*24130255 Trần Anh Quốc
lop ket noi database*/
public class AppDbContext : DbContext
{
    public DbSet<User> Users => Set<User>();
    public DbSet<Vehicle> Vehicles => Set<Vehicle>();
    public DbSet<ParkingSlot> ParkingSlots => Set<ParkingSlot>();
    public DbSet<Ticket> Tickets => Set<Ticket>();
    public DbSet<PriceConfig>  PriceConfigs => Set<PriceConfig>();
    public DbSet<MonthlySubscriber>  MonthlySubscribers => Set<MonthlySubscriber>();
    public DbSet<Invoice>  Invoices => Set<Invoice>();
    
    public AppDbContext() { }
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured) return;
        
        // File DB nằm cạnh file .exe, trong thư mục "database"
        var folder = Path.Combine(AppContext.BaseDirectory, "database");
        Directory.CreateDirectory(folder);
        var dbPath = Path.Combine(folder, "AppBaiDoXeThongMinh");
        
        optionsBuilder.UseSqlite($"Filename={dbPath}");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        
        // ---------------- User -----------
        modelBuilder.Entity<User>(e =>
        {
            e.HasKey(x => x.UserId);
            e.HasIndex(x => x.UserName).IsUnique();
            e.Property(x => x.UserName).IsRequired().HasMaxLength(50);
            e.Property(x => x.PasswordHash).IsRequired();
            e.Property(x => x.Role).HasConversion<string>();
        });
        
        // ---------------- Vehicle -----------
        modelBuilder.Entity<Vehicle>(e =>
        {
            e.HasKey(x => x.VehicleId);
            e.HasIndex(x => x.LicensePlate);
            e.Property(x => x.LicensePlate).IsRequired().HasMaxLength(20);
            e.Property(x => x.VehicleType).HasConversion<string>();
        });
        
        // ---------------- ParkingSlot -----------
        modelBuilder.Entity<ParkingSlot>(e =>
        {
            e.HasKey(x => x.SlotId);
            e.Property(x => x.SlotName).IsRequired().HasMaxLength(20);
            e.Property(x => x.AllowedVehicleType).HasConversion<string>();
        });
        
        // ---------------- PriceConfig -----------
        modelBuilder.Entity<PriceConfig>(e =>
        {
            e.HasKey(x => x.ConfigId);
            e.Property(x => x.VehicleType).HasConversion<string>();
            e.Property(x => x.DayPrice).HasPrecision(18, 2);
            e.Property(x => x.NightPrice).HasPrecision(18, 2);
            e.Property(x => x.TimeUnit).HasConversion<string>();
            e.Property(x => x.NightStart).HasPrecision(18, 2);
            e.Property(x => x.NightEnd).HasPrecision(18, 2);
            e.Property(x => x.LostTicketFee).HasPrecision(18, 2);
        });
        
        // ---------------- MonthlySubscriber -----------
        modelBuilder.Entity<MonthlySubscriber>(e =>
        {
            e.HasKey(x => x.SubcriberId);
            e.HasIndex(x => x.LicensePlate);
            e.Property(x => x.LicensePlate).IsRequired().HasMaxLength(20);
            e.Property(x => x.VehicleType).HasConversion<string>();
            e.Property(x => x.MonthlyFee).HasPrecision(18, 2);
        });
        
        // ---------------- Ticket -----------
        modelBuilder.Entity<Ticket>(e =>
        {
            e.HasKey(x => x.TicketId);
            e.HasIndex(x => x.TicketCode).IsUnique();
            e.HasIndex(x => x.VehicleId);
            e.HasIndex(x => x.Status);
            e.Property(x => x.TicketCode).IsRequired().HasMaxLength(30);
            e.Property(x => x.VehicleId).HasConversion<string>();
            e.Property(x => x.Status).HasConversion<string>();
            e.Property(x => x.TotalAmount).HasPrecision(18, 2);
            e.HasOne(x => x.Vehicle)
                .WithMany(v => v.Ticket)
                .HasForeignKey(x => x.VehicleId)
                .OnDelete(DeleteBehavior.Restrict);
            e.HasOne(x => x.PriceConfig)
                .WithMany()
                .HasForeignKey(x => x.PriceConfigId)
                .OnDelete(DeleteBehavior.Restrict);
            e.HasOne(x => x.ParkingSlot)
                .WithMany()
                .HasForeignKey(x => x.ParkingSlotId)
                .OnDelete(DeleteBehavior.SetNull);
        });
        
        // ---------------- Invoice -----------
        modelBuilder.Entity<Invoice>(e =>
        {
            e.HasKey(x => x.InvoiceId);
            e.HasIndex(x => x.PaymantDate);
            e.Property(x => x.PaymantMethod).HasConversion<string>();
            e.Property(x => x.TotalAmounnt).HasPrecision(18, 2);
            e.HasOne<Ticket>()
                .WithMany()
                .HasForeignKey(x => x.TicketId)
                .OnDelete(DeleteBehavior.Restrict);
            e.HasOne<User>()
                .WithMany()
                .HasForeignKey(x => x.CreatedBy)
                .OnDelete(DeleteBehavior.Restrict);
        });
        
        // ---------------- Dữ liệu mẫu: Cấu hình giá theo đề -----------
    }
}