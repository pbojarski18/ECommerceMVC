namespace ECommerceMVC.Application.Dtos.Baskets;

public class AddBasketDto
{
    public string UserId { get; set; }
    public int ProductId { get; set; }

    public int ProductQuantity { get; set; }

    public double TotalCost { get; set; }

    public bool IsActive { get; set; }
}
