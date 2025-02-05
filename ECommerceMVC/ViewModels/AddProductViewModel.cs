using ECommerceMVC.Application.Dtos.Categories;
using ECommerceMVC.Application.Dtos.Products;

namespace ECommerceMVC.ViewModels;

public class AddProductViewModel
{
    public AddProductDto AddProductDto { get; set; } = new AddProductDto
    {
        Name = string.Empty,
        Price = 0.0,
        Brand = string.Empty,
        Description = string.Empty,
        ImagePath = string.Empty,
        ProductDetails = new List<AddProductDetailsDto>()
    };

    public IEnumerable<ProductCategoryDto> Categories { get; set; } = new List<ProductCategoryDto>();
}