using ECommerceMVC.Application.Dtos.Products;
using ECommerceMVC.Domain.Entities;

namespace ECommerceMVC.Domain.Repositories;

public interface IProductRepository
{
    Task<IEnumerable<ProductEntity>> GetAllByFiltersAsync(CancellationToken ct);

    Task<int> AddAsync(ProductEntity product, CancellationToken ct);

    Task<bool> RemoveAsync(int productId, CancellationToken ct);

    Task<bool> EditAsync(ProductEntity product, CancellationToken ct);

    Task<ProductEntity> GetByIdAsync(int productId, CancellationToken ct);

    Task<IEnumerable<ProductEntity>> GetPagedByUserFiltersAsync(GetPagedByFiltersTransferDto filters, CancellationToken ct);
}