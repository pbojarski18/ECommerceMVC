namespace ECommerceMVC.Application.Dtos.Products;

public class AddProductDto
{
    public required string Name { get; set; }

    public required double Price { get; set; }

    public required string Brand { get; set; }

    public required string Description { get; set; }

    public required string ImagePath { get; set; }

    public int ProductSubcategoryId { get; set; }

    public List<AddProductDetailsDto> ProductDetails { get; set; } = new List<AddProductDetailsDto>();
}