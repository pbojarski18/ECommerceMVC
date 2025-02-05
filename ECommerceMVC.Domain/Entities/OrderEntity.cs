using ECommerceMVC.Domain.Entities.Common;
using ECommerceMVC.Domain.Enums;

namespace ECommerceMVC.Domain.Entities;

public class OrderEntity : AuditableEntity
{
    public string UserId { get; set; }

    public int AddressId { get; set; }

    public OrderStatusType OrderStatus { get; set; }

    public virtual ApplicationUser User { get; set; }

    public virtual AddressEntity Address { get; set; }

    public virtual ICollection<ProductOrderEntity> ProductOrders { get; set; }
}