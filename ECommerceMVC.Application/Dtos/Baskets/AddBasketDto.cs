namespace ECommerceMVC.Application.Dtos.Baskets;

public class AddBasketDto
{
    public int ProductId { get; set; }

    public int ProductQuantity { get; set; }

    public double TotalCost { get; set; }

    public bool IsActive { get; set; }
}
