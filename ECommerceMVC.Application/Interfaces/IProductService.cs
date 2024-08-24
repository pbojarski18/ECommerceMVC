using ECommerceMVC.Application.Dtos.Categories;
using ECommerceMVC.Application.Dtos.Products;
using ECommerceMVC.Application.Services;
using ECommerceMVC.Domain.Enums;

namespace ECommerceMVC.Application.Interfaces;

public interface IProductService
{
    Task<IEnumerable<ProductDto>> GetAllByFiltersAsync(CancellationToken ct);

    Task<int> AddAsync(AddProductDto addProductDto, CancellationToken ct);

    Task<bool> RemoveAsync(int productId, CancellationToken ct);

    Task<bool> EditAsync(EditProductDto editProductDto, CancellationToken ct);

    Task<ProductDto> GetByIdAsync(int productId, CancellationToken ct);

    Task<IEnumerable<ProductDto>> GetPagedByUserFiltersAsync(GetPagedByFiltersTransferDto filters, CancellationToken ct);

    Task<IEnumerable<ProductCategoryDto>> GetAllAsync(CancellationToken ct);
}
