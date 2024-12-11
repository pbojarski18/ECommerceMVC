namespace ECommerceMVC.Application.Dtos.Products;

public class AddProductDto
{
    public string Name { get; set; } = string.Empty;

    public double Price { get; set; }

    public string Brand { get; set; } = string.Empty;

    public string Description { get; set; } = string.Empty;

    public string ImagePath { get; set; } = string.Empty;

    public int ProductSubcategoryId { get; set; }

    public List<AddProductDetailsDto> ProductDetails { get; set; } = new List<AddProductDetailsDto>();
}