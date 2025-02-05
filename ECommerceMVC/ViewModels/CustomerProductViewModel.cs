using ECommerceMVC.Application.Dtos.Categories;

namespace ECommerceMVC.Application.Dtos.Products;

/// <summary>
/// ViewModel that is required for CustomerProduct.cshtml which provides view based on categories, filters and products list
/// </summary>
public class CustomerProductViewModel
{
    public int TotalCount { get; set; }

    public int PageSize { get; set; }

    public int CurrentPage { get; set; }

    public IEnumerable<ProductDto> Products { get; set; } = new List<ProductDto>(); // same as []

    public GetPagedByFiltersTransferDto GetPagedByFiltersTransferDto { get; set; } = new();

    public IEnumerable<ProductCategoryDto> ProductCategories { get; set; } = [];
}