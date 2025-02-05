using ECommerceMVC.Domain.Entities;

namespace ECommerceMVC.ViewModels;

public class OrderViewModel
{
    public ApplicationUser User { get; set; }

    public string Country { get; set; }

    public string City { get; set; }

    public string Street { get; set; }

    public string PostalCode { get; set; }

    public string BuildingNumber { get; set; }

    public string? ApartmentNumber { get; set; }
}