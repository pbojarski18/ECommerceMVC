using ECommerceMVC.Application.Dtos.Products;

namespace ECommerceMVC.Application.Dtos.Baskets;

public class BasketDto
{
    public int Id { get; set; }
    public ProductDto Product { get; set; } = new ProductDto();

    public int ProductQuantity { get; set; }
    public double TotalCost { get; set; }
}