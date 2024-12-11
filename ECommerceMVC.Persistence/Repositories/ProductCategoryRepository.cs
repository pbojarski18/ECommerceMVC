using ECommerceMVC.Domain.Entities;
using ECommerceMVC.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace ECommerceMVC.Persistence.Repositories;

public class ProductCategoryRepository(IBaseRepository _baseRepository) : IProductCategoryRepository
{
    private readonly IBaseRepository _baseRepository = _baseRepository;

    public async Task<IEnumerable<ProductCategoryEntity>> GetAllAsync(CancellationToken ct)
    {
        var categories = await _baseRepository.GetAll<ProductCategoryEntity>()
                                        .Include(p => p.ProductSubcategories)
                                        .ToListAsync(ct);

        return categories;
    }
}