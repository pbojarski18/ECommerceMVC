using ECommerceMVC.Application.Dtos.Products;
using ECommerceMVC.Application.Services;
using ECommerceMVC.Domain.Enums;

namespace ECommerceMVC.Application.Interfaces;

public interface IProductService
{
    Task<IEnumerable<ProductDto>> GetAllByFiltersAsync(ProductType productType, CancellationToken ct);

    Task<int> AddAsync(ProductDto productDto, CancellationToken ct);

    Task<bool> RemoveAsync(int productId, CancellationToken ct);

    Task<bool> EditAsync(ProductDto productDto, CancellationToken ct);

    Task<ProductDto> GetByIdAsync(int productId, CancellationToken ct);

    Task<IEnumerable<ProductDto>> GetPagedByUserFiltersAsync(GetPagedByFiltersTransferDto filters, CancellationToken ct);
}
