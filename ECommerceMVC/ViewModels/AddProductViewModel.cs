using ECommerceMVC.Application.Dtos.Categories;
using ECommerceMVC.Application.Dtos.Products;

namespace ECommerceMVC.ViewModels;

public class AddProductViewModel
{
    public AddProductDto AddProductDto { get; set; } = new AddProductDto();

    public IEnumerable<ProductCategoryDto> Categories { get; set; } = new List<ProductCategoryDto>();
}
