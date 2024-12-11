using ECommerceMVC.Domain.Entities.Common;

namespace ECommerceMVC.Domain.Entities;

public class StockEntity : AuditableEntity
{
    public int ProductQuantity { get; set; }

    public int ProductId { get; set; }

    public virtual ProductEntity Product { get; set; }

    public virtual ICollection<StockHistoryEntity> StockHistories { get; set; }
}