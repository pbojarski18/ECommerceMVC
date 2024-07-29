using ECommerceMVC.Domain.Entities.Common;

namespace ECommerceMVC.Domain.Entities;

public class OrderEntity : AuditableEntity
{
    public string UserEmail  { get; set; }

    public string UserFirstName { get; set; }

    public string UserLastName { get; set; }

    public string UserAddress { get; set; }

    public string UserCity { get; set; }

    public string PostalCode { get; set; }

    public string PhoneNumber { get; set; }

    public virtual ICollection<ProductOrderEntity> ProductOrders { get; set; }
}
