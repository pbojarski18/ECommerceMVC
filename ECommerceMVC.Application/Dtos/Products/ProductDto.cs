using ECommerceMVC.Domain.Enums;

namespace ECommerceMVC.Application.Dtos.Products;

public class ProductDto
{
    public int Id { get; set; }
    public double Price { get; set; }

    public string Name { get; set; }

    public string Description { get; set; }

    public string ImagePath { get; set; }

    public string Brand { get; set; }

    public string Sex { get; set; }

    public ProductType ProductType { get; set; }
}
