using ECommerceMVC.Application.Dtos.Products;
using ECommerceMVC.Application.Services;
using ECommerceMVC.Domain.Enums;

namespace ECommerceMVC.Application.Interfaces;

public interface IProductService
{
    Task<IEnumerable<ProductDto>> GetAllByFiltersAsync(ProductType productType, CancellationToken ct);

    Task<int> AddAsync(ProductDto productDto, CancellationToken ct);
}
