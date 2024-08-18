using ECommerceMVC.Domain.Entities.Common;
using ECommerceMVC.Domain.Enums;
using Microsoft.AspNetCore.Identity;

namespace ECommerceMVC.Domain.Entities;

public class OrderEntity : AuditableEntity
{
    public string UserId { get; set; }
    public string UserEmail { get; set; }

    public string UserFirstName { get; set; }

    public string UserLastName { get; set; }

    public string UserAddress { get; set; }

    public string UserCity { get; set; }

    public string PostalCode { get; set; }

    public string PhoneNumber { get; set; }

    public OrderStatusType OrderStatus { get; set; }

    public virtual IdentityUser User { get; set; }
    public virtual ICollection<ProductOrderEntity> ProductOrders { get; set; }
}
