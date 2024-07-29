using ECommerceMVC.Domain.Entities.Common;

namespace ECommerceMVC.Domain.Entities;

public class ProductOrderEntity : AuditableEntity
{
    public int ProductId { get; set; }

    public int OrderId { get; set; }


    public virtual OrderEntity Order { get; set; }

    public virtual ProductEntity Product { get; set; }
}
