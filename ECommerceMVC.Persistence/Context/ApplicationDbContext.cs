using ECommerceMVC.Application.Abstraction;
using ECommerceMVC.Domain.Entities;
using ECommerceMVC.Persistence.Seed;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using System.Data;

namespace ECommerceMVC.Persistence.Context;

public class ApplicationDbContext : IdentityDbContext<IdentityUser>, IUnitOfWork
{
    public DbSet<ProductEntity> Products { get; set; }

    public DbSet<OrderEntity> Orders { get; set; }

    public DbSet<ProductCategoryEntity> ProductCategories { get; set; }

    public DbSet<ProductOrderEntity> ProductOrders { get; set; }

    public DbSet<StockEntity> Stocks { get; set; }

    public DbSet<StockHistoryEntity> StockHistories { get; set; }

    public DbSet<BasketEntity> Baskets { get; set; }

    public DbSet<ProductDetailsEntity> ProductDetails { get; set; }

    public DbSet<ProductSubcategoryEntity> ProductSubcategories { get; set; }

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
            .HasOne(p => p.ProductSubcategory)
            .WithMany(p => p.Products)
            .HasForeignKey(p => p.ProductSubcategoryId);
        modelBuilder.Entity<ProductEntity>()
            .Property(p => p.Brand)
            .IsRequired();


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
            .Property(p => p.ProductQuantity)
            .IsRequired();
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
        modelBuilder.Entity<OrderEntity>()
            .HasOne(p => p.User)
            .WithMany()
            .HasForeignKey(p => p.UserId);

        modelBuilder.Entity<ProductCategoryEntity>()
            .HasKey(p => p.Id);
        modelBuilder.Entity<ProductCategoryEntity>()
            .Property(p => p.Name)
            .IsRequired()
            .HasMaxLength(20);

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

        modelBuilder.Entity<BasketEntity>()
            .HasKey(p => p.Id);
        modelBuilder.Entity<BasketEntity>()
            .Property(p => p.ProductId)
            .IsRequired();
        modelBuilder.Entity<BasketEntity>()
            .Property(p => p.ProductQuantity)
            .IsRequired();
        modelBuilder.Entity<BasketEntity>()
            .Property(p => p.TotalCost)
            .IsRequired();
        modelBuilder.Entity<BasketEntity>()
            .Property(p => p.IsActive)
            .IsRequired();
        modelBuilder.Entity<BasketEntity>()
            .HasOne(p => p.Product)
            .WithMany(p => p.Baskets)
            .HasForeignKey(p => p.ProductId);
        modelBuilder.Entity<BasketEntity>()
           .HasOne(p => p.User)
           .WithMany()
           .HasForeignKey(p => p.UserId);

        modelBuilder.Entity<ProductDetailsEntity>()
            .HasKey(p => p.Id);
        modelBuilder.Entity<ProductDetailsEntity>()
            .Property(p => p.Key)
            .IsRequired()
            .HasMaxLength(30);
        modelBuilder.Entity<ProductDetailsEntity>()
            .Property(p => p.Value)
            .IsRequired()
            .HasMaxLength(50);
        modelBuilder.Entity<ProductDetailsEntity>()
            .Property(p => p.IsMain)
            .IsRequired();
        modelBuilder.Entity<ProductDetailsEntity>()
            .Property(p => p.Key)
            .IsRequired()
            .HasMaxLength(30);
        modelBuilder.Entity<ProductDetailsEntity>()
            .HasOne(p => p.Product)
            .WithMany(p => p.ProductDetails)
            .HasForeignKey(p => p.ProductId);

        modelBuilder.Entity<ProductSubcategoryEntity>()
            .HasKey(p => p.Id);
        modelBuilder.Entity<ProductSubcategoryEntity>()
            .Property(p => p.Name)
            .IsRequired()
            .HasMaxLength(30);
        modelBuilder.Entity<ProductSubcategoryEntity>()
            .HasOne(p => p.ProductCategory)
            .WithMany(p => p.ProductSubcategories)
            .HasForeignKey(p => p.ProductCategoryId);

        modelBuilder.DataSeed();
    }

    public async Task<IDbTransaction> BeginTransactionAsync()
    {
        return (await Database.BeginTransactionAsync()).GetDbTransaction();
    }
}


