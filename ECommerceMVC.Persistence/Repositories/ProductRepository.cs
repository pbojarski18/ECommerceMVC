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

    public async Task<int> AddAsync(ProductEntity product, CancellationToken ct)
    {
        await _baseRepository.AddAsync<ProductEntity>(product, ct);
        await _baseRepository.SaveAsync(ct);

        return product.Id;
    }

    public async Task<bool> RemoveAsync(int productId, CancellationToken ct)
    {
        var product = await _baseRepository.GetAll<ProductEntity>()
            .FirstOrDefaultAsync(p => p.Id == productId);

        if (product == null)
        {
            return false;
        }

        _baseRepository.Delete(product);
        await _baseRepository.SaveAsync(ct);

        return true;
    }

    public async Task<bool> EditAsync(ProductEntity product, CancellationToken ct)
    {
        _baseRepository.Update<ProductEntity>(product);
        await _baseRepository.SaveAsync(ct);

        return true;
    }

    public async Task<ProductEntity> GetByIdAsync(int productId, CancellationToken ct)
    {
        var product = await _baseRepository.GetAll<ProductEntity>()
            .FirstOrDefaultAsync(p => p.Id == productId, ct);
        if (product == null)
        {
            throw new Exception("Product not found");
        }
        else
        {
            return product;
        }
    }
}

