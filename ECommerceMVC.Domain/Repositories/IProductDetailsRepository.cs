using ECommerceMVC.Domain.Entities;

namespace ECommerceMVC.Domain.Repositories;

public interface IProductDetailsRepository
{
    Task<bool> AddRangeAsync(IEnumerable<ProductDetailsEntity> productDetails, CancellationToken ct);
}
