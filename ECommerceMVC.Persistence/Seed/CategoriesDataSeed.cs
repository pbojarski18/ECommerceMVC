using ECommerceMVC.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace ECommerceMVC.Persistence.Seed;

public static class CategoriesDataSeed
{
    public static void DataSeed(this ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ProductCategoryEntity>()
                    .HasData(new ProductCategoryEntity() { Id = 1, CreateTimeUtc = DateTimeOffset.MinValue, Name = "Rackets" },
                             new ProductCategoryEntity() { Id = 2, CreateTimeUtc = DateTimeOffset.MinValue, Name = "Clothes" },
                             new ProductCategoryEntity() { Id = 3, CreateTimeUtc = DateTimeOffset.MinValue, Name = "Shoes" },
                             new ProductCategoryEntity() { Id = 4, CreateTimeUtc = DateTimeOffset.MinValue, Name = "Bags" },
                             new ProductCategoryEntity() { Id = 5, CreateTimeUtc = DateTimeOffset.MinValue, Name = "Balls" },
                             new ProductCategoryEntity() { Id = 6, CreateTimeUtc = DateTimeOffset.MinValue, Name = "Strings" },
                             new ProductCategoryEntity() { Id = 7, CreateTimeUtc = DateTimeOffset.MinValue, Name = "Accessories" });

        modelBuilder.Entity<ProductSubcategoryEntity>()
                    .HasData(new ProductSubcategoryEntity() { Id = 1, CreateTimeUtc = DateTimeOffset.MinValue, Name = "Adult Rackets", ProductCategoryId = 1 },
                             new ProductSubcategoryEntity() { Id = 2, CreateTimeUtc = DateTimeOffset.MinValue, Name = "Junior Rackets", ProductCategoryId = 1 },

                             new ProductSubcategoryEntity() { Id = 3, CreateTimeUtc = DateTimeOffset.MinValue, Name = "Male Clothes", ProductCategoryId = 2 },
                             new ProductSubcategoryEntity() { Id = 4, CreateTimeUtc = DateTimeOffset.MinValue, Name = "Female Clothes", ProductCategoryId = 2 },

                             new ProductSubcategoryEntity() { Id = 5, CreateTimeUtc = DateTimeOffset.MinValue, Name = "Male Shoes", ProductCategoryId = 3 },
                             new ProductSubcategoryEntity() { Id = 6, CreateTimeUtc = DateTimeOffset.MinValue, Name = "Female Shoes", ProductCategoryId = 3 },
                             new ProductSubcategoryEntity() { Id = 7, CreateTimeUtc = DateTimeOffset.MinValue, Name = "Junior Shoes", ProductCategoryId = 3 },

                             new ProductSubcategoryEntity() { Id = 8, CreateTimeUtc = DateTimeOffset.MinValue, Name = "Tennis Bags", ProductCategoryId = 4 },
                             new ProductSubcategoryEntity() { Id = 9, CreateTimeUtc = DateTimeOffset.MinValue, Name = "Sport Bags", ProductCategoryId = 4 },
                             new ProductSubcategoryEntity() { Id = 10, CreateTimeUtc = DateTimeOffset.MinValue, Name = "Backpacks", ProductCategoryId = 4 },

                             new ProductSubcategoryEntity() { Id = 11, CreateTimeUtc = DateTimeOffset.MinValue, Name = "Balls", ProductCategoryId = 5 },

                             new ProductSubcategoryEntity() { Id = 12, CreateTimeUtc = DateTimeOffset.MinValue, Name = "Strings", ProductCategoryId = 6 },

                             new ProductSubcategoryEntity() { Id = 13, CreateTimeUtc = DateTimeOffset.MinValue, Name = "Grips", ProductCategoryId = 7 },
                             new ProductSubcategoryEntity() { Id = 14, CreateTimeUtc = DateTimeOffset.MinValue, Name = "Overgrips", ProductCategoryId = 7 },
                             new ProductSubcategoryEntity() { Id = 15, CreateTimeUtc = DateTimeOffset.MinValue, Name = "Shock Absorbers", ProductCategoryId = 7 });
    }
}