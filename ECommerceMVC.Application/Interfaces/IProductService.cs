using ECommerceMVC.Application.Dtos.Categories;
using ECommerceMVC.Application.Dtos.Products;

namespace ECommerceMVC.Application.Interfaces;

public interface IProductService
{
    Task<IEnumerable<ProductDto>> GetAllByFiltersAsync(CancellationToken ct);

    Task<int> AddAsync(AddProductDto addProductDto, CancellationToken ct);

    Task RemoveAsync(int productId, CancellationToken ct);

    Task EditAsync(EditProductDto editProductDto, CancellationToken ct);

    Task<ProductDto> GetByIdAsync(int productId, CancellationToken ct);

    Task<IEnumerable<ProductDto>> GetPagedByUserFiltersAsync(GetPagedByFiltersTransferDto filters, CancellationToken ct);

    Task<IEnumerable<ProductCategoryDto>> GetAllCategoriesAsync(CancellationToken ct);

    Task RemoveDetailAsync(int productDetailId, CancellationToken ct);
}