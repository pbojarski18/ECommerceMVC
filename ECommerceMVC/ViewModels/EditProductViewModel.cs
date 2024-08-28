using ECommerceMVC.Application.Dtos.Categories;
using ECommerceMVC.Application.Dtos.Products;

namespace ECommerceMVC.ViewModels;

public class EditProductViewModel
{
    public EditProductDto EditProductDto { get; set; } = new EditProductDto();

    public IEnumerable<ProductCategoryDto> Categories { get; set; } = new List<ProductCategoryDto>();
}
