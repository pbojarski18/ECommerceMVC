using ECommerceMVC.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace ECommerceMVC.Persistence.Context;

public class ApplicationDbContext : DbContext
{
    public DbSet<ProductEntity> Products { get; set; }

    public DbSet<OrderEntity> Orders { get; set; }

    public DbSet<ProductCategoryEntity> ProductCategories { get; set; }

    public DbSet<ProductOrderEntity> ProductOrders { get; set; }

    public DbSet<StockEntity> Stocks { get; set; }

    public DbSet<StockHistoryEntity> StockHistories { get; set; }

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<ProductEntity>()
            .HasKey(p => p.Id);
        modelBuilder.Entity<ProductEntity>()
            .Property(p => p.Name)
            .IsRequired()
            .HasMaxLength(50);
        modelBuilder.Entity<ProductEntity>()
            .Property(p => p.ImagePath)
            .IsRequired();
        modelBuilder.Entity<ProductEntity>()
            .Property(p => p.Price)
            .IsRequired();
        modelBuilder.Entity<ProductEntity>()
            .Property(p => p.Description)
            .IsRequired()
            .HasMaxLength(1000);
        modelBuilder.Entity<ProductEntity>()
            .HasOne(p => p.ProductCategory)
            .WithMany(p => p.Products)
            .HasForeignKey(p => p.ProductCategoryId);
        modelBuilder.Entity<ProductEntity>()
            .Property(p => p.Weight)
            .IsRequired(false);


        modelBuilder.Entity<StockEntity>()
            .HasKey(p => p.Id);
        modelBuilder.Entity<StockEntity>()
            .HasOne(p => p.Product)
            .WithOne(p => p.Stock);
        modelBuilder.Entity<StockEntity>()
            .Property(p => p.ProductQuantity)
            .IsRequired();

        modelBuilder.Entity<ProductOrderEntity>()
            .HasKey(p => p.Id);
        modelBuilder.Entity<ProductOrderEntity>()
            .HasOne(p => p.Order)
            .WithMany(p => p.ProductOrders)
            .HasForeignKey(p => p.OrderId);
        modelBuilder.Entity<ProductOrderEntity>()
            .HasOne(p => p.Product)
            .WithMany(p => p.ProductOrders)
            .HasForeignKey(p => p.ProductId);

        modelBuilder.Entity<OrderEntity>()
            .HasKey(p => p.Id);
        modelBuilder.Entity<OrderEntity>()
            .Property(p => p.UserEmail)
            .IsRequired();
        modelBuilder.Entity<OrderEntity>()
            .Property(p => p.UserFirstName)
            .IsRequired();
        modelBuilder.Entity<OrderEntity>()
            .Property(p => p.UserLastName)
            .IsRequired();
        modelBuilder.Entity<OrderEntity>()
            .Property(p => p.UserAddress)
            .IsRequired();
        modelBuilder.Entity<OrderEntity>()
            .Property(p => p.UserCity)
            .IsRequired();
        modelBuilder.Entity<OrderEntity>()
            .Property(p => p.PostalCode)
            .IsRequired();
        modelBuilder.Entity<OrderEntity>()
            .Property(p => p.PhoneNumber)
            .IsRequired();
        modelBuilder.Entity<OrderEntity>()
            .Property(p => p.OrderStatus)
            .IsRequired()
            .HasConversion<string>();

        modelBuilder.Entity<ProductCategoryEntity>()
            .HasKey(p => p.Id);
        modelBuilder.Entity<ProductCategoryEntity>()
            .Property(p => p.Brand)
            .IsRequired();
        modelBuilder.Entity<ProductCategoryEntity>()
            .Property(p => p.Sex)
            .IsRequired();
        modelBuilder.Entity<ProductCategoryEntity>()
            .Property(p => p.ProductType)
            .IsRequired().HasConversion<string>();

        modelBuilder.Entity<StockHistoryEntity>()
            .HasKey(p => p.Id);
        modelBuilder.Entity<StockHistoryEntity>()
            .Property(p => p.ProductQuantity)
            .IsRequired();
        modelBuilder.Entity<StockHistoryEntity>()
            .Property(p => p.ProductId)
            .IsRequired();
        modelBuilder.Entity<StockHistoryEntity>()
            .HasOne(p => p.Stock)
            .WithMany(p => p.StockHistories)
            .HasForeignKey(p => p.StockId);
        modelBuilder.Entity<StockHistoryEntity>()
            .Property(p => p.Message)
            .IsRequired()
            .HasMaxLength(100);

    }
}


