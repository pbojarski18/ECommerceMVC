using ECommerceMVC.Domain.Entities.Common;

namespace ECommerceMVC.Domain.Entities;

public class BasketEntity : AuditableEntity
{
    public int ProductId { get; set; }
    
    public int ProductQuantity { get; set; }

    public double TotalCost {  get; set; }

    public bool IsActive { get; set; }

    public virtual ProductEntity Product { get; set; }

}

