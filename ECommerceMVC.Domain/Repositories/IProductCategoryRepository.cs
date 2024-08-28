using ECommerceMVC.Domain.Entities;
using ECommerceMVC.Domain.Enums;

namespace ECommerceMVC.Domain.Repositories;

public interface IProductCategoryRepository
{
    Task<IEnumerable<ProductCategoryEntity>> GetAllAsync(CancellationToken ct);

}
