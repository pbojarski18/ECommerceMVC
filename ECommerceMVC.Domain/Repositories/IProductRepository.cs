using ECommerceMVC.Domain.Entities;
using ECommerceMVC.Domain.Enums;

namespace ECommerceMVC.Domain.Repositories;

public interface IProductRepository
{
    Task<IEnumerable<ProductEntity>> GetAllByFiltersAsync(ProductType productType, CancellationToken ct);
}
