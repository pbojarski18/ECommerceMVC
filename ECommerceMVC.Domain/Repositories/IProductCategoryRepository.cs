using ECommerceMVC.Domain.Entities;
using ECommerceMVC.Domain.Enums;

namespace ECommerceMVC.Domain.Repositories;

public interface IProductCategoryRepository
{
    Task<ProductCategoryEntity> GetByPropertiesAsync(string brand, string sex, ProductType productType, CancellationToken ct);
}
