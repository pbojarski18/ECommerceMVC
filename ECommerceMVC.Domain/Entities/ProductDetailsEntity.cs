using ECommerceMVC.Domain.Entities.Common;

namespace ECommerceMVC.Domain.Entities;

public class ProductDetailsEntity : AuditableEntity
{
    public string Key { get; set; }

    public string Value { get; set; }

    public bool IsMain { get; set; }

    public virtual ProductEntity Product { get; set; }

    public int ProductId { get; set; }
}
