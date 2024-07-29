using ECommerceMVC.Domain.Entities.Common;
using ECommerceMVC.Domain.Enums;

namespace ECommerceMVC.Domain.Entities;

public class ProductCategoryEntity : AuditableEntity
{
    public string Brand { get; set; }

    public string Sex { get; set; }

    public ProductType ProductType { get; set; }


    public virtual ICollection <ProductEntity> Products { get; set; }

}
