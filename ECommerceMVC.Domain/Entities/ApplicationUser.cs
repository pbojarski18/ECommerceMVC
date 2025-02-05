using Microsoft.AspNetCore.Identity;

namespace ECommerceMVC.Domain.Entities;

public class ApplicationUser : IdentityUser
{
    public string FirstName { get; set; }

    public string LastName { get; set; }

    public ICollection<AddressEntity> Addresses { get; set; }

    public ICollection<OrderEntity> Orders { get; set; }
}