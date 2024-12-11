namespace ECommerceMVC.Application.Dtos.Products;

public class EditProductDto
{
    public int Id { get; set; }

    public string Name { get; set; } = string.Empty;

    public double Price { get; set; }

    public string Brand { get; set; } = string.Empty;

    public string Description { get; set; } = string.Empty;

    public string ImagePath { get; set; } = string.Empty;

    public int ProductSubcategoryId { get; set; }
    public List<ProductDetailsDto> Details { get; set; } = new List<ProductDetailsDto>();

    public EditProductDto()
    {
    }

    public EditProductDto(ProductDto model)
    {
        Id = model.Id;
        Name = model.Name;
        Price = model.Price;
        Brand = model.Brand;
        Description = model.Description;
        ImagePath = model.ImagePath;
        ProductSubcategoryId = model.ProductSubcategoryId;
        Details = model.ProductDetails;
    }
}