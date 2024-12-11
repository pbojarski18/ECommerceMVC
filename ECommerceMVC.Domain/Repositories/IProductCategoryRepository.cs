using ECommerceMVC.Domain.Entities;

namespace ECommerceMVC.Domain.Repositories;

public interface IProductCategoryRepository
{
    Task<IEnumerable<ProductCategoryEntity>> GetAllAsync(CancellationToken ct);
}