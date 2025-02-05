using ECommerceMVC.Application.Dtos.Products;
using ECommerceMVC.Domain.Entities;
using ECommerceMVC.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace ECommerceMVC.Persistence.Repositories;

public class ProductRepository(IBaseRepository _baseRepository) : IProductRepository
{
    public async Task<IEnumerable<ProductEntity>> GetAllByFiltersAsync(CancellationToken ct)
    {
        var products = await _baseRepository.GetAll<ProductEntity>()
                                            .ToListAsync(ct);

        return products;
    }

    public async Task<IEnumerable<ProductEntity>> GetPagedByUserFiltersAsync(GetPagedByFiltersTransferDto filters, CancellationToken ct)
    {
        var query = _baseRepository.GetAll<ProductEntity>()
            .Include(p => p.ProductDetails)
            .Include(p => p.Stock)
            .Where(p => p.ProductSubcategoryId == filters.ProductSubcategoryId);

        if (filters.MinPrice > 0)
        {
            query = query.Where(p => p.Price >= filters.MinPrice);
        }

        if (filters.MaxPrice > 0)
        {
            query = query.Where(p => p.Price <= filters.MaxPrice);
        }

        filters.TotalCount = await query.CountAsync(ct);

        var pagedQuery = query.OrderBy(p => p.Price)
            .Skip(filters.CurrentPage * filters.PageSize - filters.PageSize)
            .Take(filters.PageSize);

        return await pagedQuery.ToListAsync(ct);
    }

    public async Task<int> AddAsync(ProductEntity product, CancellationToken ct)
    {
        await _baseRepository.AddAsync<ProductEntity>(product, ct);
        await _baseRepository.SaveAsync(ct);

        return product.Id;
    }

    public async Task RemoveAsync(int productId, CancellationToken ct)
    {
        var product = await _baseRepository.GetAll<ProductEntity>()
            .FirstOrDefaultAsync(p => p.Id == productId, ct);

        if (product == null)
        {
            throw new Exception("Product not found");
        }

        _baseRepository.Delete(product);
        await _baseRepository.SaveAsync(ct);
    }

    public async Task EditAsync(ProductEntity product, CancellationToken ct)
    {
        _baseRepository.Update<ProductEntity>(product);
        await _baseRepository.SaveAsync(ct);
    }

    public async Task<ProductEntity> GetByIdAsync(int productId, CancellationToken ct)
    {
        var product = await _baseRepository.GetAll<ProductEntity>()
                                           .Include(p => p.ProductDetails)
                                           .Include(p => p.Stock)
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