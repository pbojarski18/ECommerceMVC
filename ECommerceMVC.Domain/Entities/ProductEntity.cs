using ECommerceMVC.Domain.Entities.Common;

namespace ECommerceMVC.Domain.Entities;

public class ProductEntity : AuditableEntity
{
    public double Price { get; set; }

    public int? Weight { get; set; }

    public int ProductCategoryId { get; set; }

    public string Name { get; set; }

    public string Description { get; set; }

    public string ImagePath { get; set; }

    public virtual ProductCategoryEntity ProductCategory { get; set; }


    public virtual StockEntity Stock { get; set; }

    public virtual ICollection<BasketEntity> Baskets { get; set; }

    public virtual ICollection<ProductOrderEntity> ProductOrders { get; set; }
}
