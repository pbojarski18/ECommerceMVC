using ECommerceMVC.Domain.Entities;
using ECommerceMVC.Domain.Enums;
using ECommerceMVC.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace ECommerceMVC.Persistence.Repositories;

public class ProductCategoryRepository(IBaseRepository _baseRepository) : IProductCategoryRepository
{
    private readonly IBaseRepository _baseRepository = _baseRepository;

    public async Task<ProductCategoryEntity> GetByPropertiesAsync(string brand, string sex, ProductType productType, CancellationToken ct)
    {
        var productCategory = await _baseRepository.GetAll<ProductCategoryEntity>()
            .FirstOrDefaultAsync(p => p.Brand == brand &&
            p.Sex == sex && p.ProductType == productType, ct);

        if (productCategory == null)
        {
            return new ProductCategoryEntity();
        }
        else
        {
            return productCategory;
        }
    }
}
