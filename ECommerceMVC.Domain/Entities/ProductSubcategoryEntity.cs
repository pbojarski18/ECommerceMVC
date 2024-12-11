using ECommerceMVC.Domain.Entities.Common;

namespace ECommerceMVC.Domain.Entities;

public class ProductSubcategoryEntity : AuditableEntity
{
    public string Name { get; set; }

    public virtual ICollection<ProductEntity> Products { get; set; }

    public virtual ProductCategoryEntity ProductCategory { get; set; }

    public int ProductCategoryId { get; set; }
}