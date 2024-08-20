using ECommerceMVC.Application.Dtos.Products;
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

    public async Task<IEnumerable<ProductEntity>> GetPagedByUserFiltersAsync(GetPagedByFiltersTransferDto filters, CancellationToken ct)
    {
        var query = _baseRepository.GetAll<ProductEntity>()
            .Include(p => p.ProductCategory)
            .Include(p => p.Stock)
            .Where(p => p.ProductCategory.ProductType == filters.ProductType);


        if (filters.MinWeight > 0)
        {
            query = query.Where(p => p.Weight >= filters.MinWeight);
        }

        if (filters.MaxWeight > 0)
        {
            query = query.Where(p => p.Weight <= filters.MaxWeight);
        }

        if (filters.MinPrice > 0)
        {
            query = query.Where(p => p.Price >= filters.MinPrice);
        }

        if (filters.MaxPrice > 0)
        {
            query = query.Where(p => p.Price <= filters.MaxPrice);
        }

        if (!string.IsNullOrEmpty(filters.Name))
        {
            query = query.Where(p => p.Name.Contains(filters.Name));
        }

        query = query.OrderBy(p => p.Price)
            .Skip(filters.CurrentPage * filters.PageSize - filters.PageSize)
            .Take(filters.PageSize);

        return await query.ToListAsync(ct);

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
            .FirstOrDefaultAsync(p => p.Id == productId, ct);

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
            .Include(p => p.ProductCategory)
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

