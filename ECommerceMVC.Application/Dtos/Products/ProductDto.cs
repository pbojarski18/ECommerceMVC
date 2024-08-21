using ECommerceMVC.Domain.Enums;

namespace ECommerceMVC.Application.Dtos.Products;

public class ProductDto
{
    public int Id { get; set; }

    public int ProductSubcategoryId { get; set; }
    public double Price { get; set; }

    public int ProductQuantity { get; set; }

    public string Name { get; set; }

    public string Description { get; set; }

    public string ImagePath { get; set; }

    public string Brand { get; set; }

}
