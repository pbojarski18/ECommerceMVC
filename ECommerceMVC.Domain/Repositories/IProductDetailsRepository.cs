using ECommerceMVC.Domain.Entities;

namespace ECommerceMVC.Domain.Repositories;

public interface IProductDetailsRepository
{
    Task AddRangeAsync(IEnumerable<ProductDetailsEntity> productDetails, CancellationToken ct);

    Task EditRangeAsync(IEnumerable<ProductDetailsEntity> productDetails, CancellationToken ct);

    Task RemoveAsync(int productDetailId, CancellationToken ct);
}