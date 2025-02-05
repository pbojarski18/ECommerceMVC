using ECommerceMVC.Domain.Entities.Common;

namespace ECommerceMVC.Domain.Entities;

public class AddressEntity : AuditableEntity
{
    public string UserId { get; set; }

    public string Country { get; set; }

    public string City { get; set; }

    public string Street { get; set; }

    public string PostalCode { get; set; }

    public string BuildingNumber { get; set; }

    public string? ApartmentNumber { get; set; }

    public virtual ApplicationUser User { get; set; }

    public ICollection<OrderEntity> Orders { get; set; }
}