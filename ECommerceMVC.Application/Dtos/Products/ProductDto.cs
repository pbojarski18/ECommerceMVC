namespace ECommerceMVC.Application.Dtos.Products;

public class ProductDto
{
    public int Id { get; set; }

    public int ProductSubcategoryId { get; set; }
    public double Price { get; set; }

    public int ProductQuantity { get; set; }

    public string Name { get; set; } = string.Empty;

    public string Description { get; set; } = string.Empty;

    public string ImagePath { get; set; } = string.Empty;

    public string Brand { get; set; } = string.Empty;

    public List<ProductDetailsDto> ProductDetails { get; set; } = new List<ProductDetailsDto>();
}