using ECommerceMVC.Domain.Entities.Common;

namespace ECommerceMVC.Domain.Entities;

public class ProductCategoryEntity : AuditableEntity
{
    public string Name { get; set; }

    public virtual ICollection<ProductSubcategoryEntity> ProductSubcategories { get; set; }
}