using ECommerceMVC.Domain.Entities.Common;

namespace ECommerceMVC.Domain.Entities;

public class ProductEntity : AuditableEntity
{
    public string Name { get; set; }
    public double Price { get; set; }

    public string Brand { get; set; }

    public string Description { get; set; }

    public string ImagePath { get; set; }

    public virtual StockEntity Stock { get; set; }

    public virtual ICollection<BasketEntity> Baskets { get; set; }

    public virtual ICollection<ProductOrderEntity> ProductOrders { get; set; }

    public virtual ICollection<ProductDetailsEntity> ProductDetails { get; set; }

    public virtual ProductSubcategoryEntity ProductSubcategory { get; set; }

    public int ProductSubcategoryId { get; set; }
}