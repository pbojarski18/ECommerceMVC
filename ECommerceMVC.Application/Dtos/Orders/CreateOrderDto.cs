namespace ECommerceMVC.Application.Dtos.Orders;

public class CreateOrderDto
{
    public string UserEmail { get; set; } = string.Empty;

    public string UserFirstName { get; set; } = string.Empty;

    public string UserLastName { get; set; } = string.Empty;

    public string UserAddress { get; set; } = string.Empty;

    public string UserCity { get; set; } = string.Empty;

    public string PostalCode { get; set; } = string.Empty;

    public string PhoneNumber { get; set; } = string.Empty;

    public string UserId { get; set; }
}