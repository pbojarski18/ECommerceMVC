using ECommerceMVC.Domain.Entities;
using ECommerceMVC.Domain.Enums;
using ECommerceMVC.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace ECommerceMVC.Persistence.Repositories;

public class ProductRepository(IBaseRepository _baseRepository) : IProductRepository
{
    private readonly IBaseRepository _baseRepository = _baseRepository;

    public async Task<IEnumerable<ProductEntity>> GetAllByFiltersAsync(ProductType productType, CancellationToken ct)
    {
        var products = await _baseRepository.GetAll<ProductEntity>()
            .Include(x => x.ProductCategory)
            .Where(p => p.ProductCategory.ProductType == productType)
            .ToListAsync(ct);

        return products;

    }
}
