namespace ECommerceMVC.Application.Dtos.Orders;

public class CreateOrderDto
{
    public required int AddressId { get; set; }

    public required string UserId { get; set; }
}