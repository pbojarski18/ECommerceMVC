using ECommerceMVC.Domain.Entities.Common;

namespace ECommerceMVC.Domain.Entities;

public class StockHistoryEntity : AuditableEntity
{
    public int ProductQuantity { get; set; }

    public int ProductId { get; set; }

    public int StockId { get; set; }

    public string Message { get; set; }

    public virtual StockEntity Stock { get; set; }
}