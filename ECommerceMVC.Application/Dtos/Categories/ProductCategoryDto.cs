using ECommerceMVC.Domain.Entities;

namespace ECommerceMVC.Application.Dtos.Categories;

public class ProductCategoryDto
{
    public int Id { get; set; }

    public string Name { get; set; }

    public IEnumerable<ProductSubcategoryDto> Subcategories { get; set; }
}
