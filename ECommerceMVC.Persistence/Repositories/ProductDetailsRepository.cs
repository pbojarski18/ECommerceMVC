using ECommerceMVC.Domain.Entities;
using ECommerceMVC.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace ECommerceMVC.Persistence.Repositories;

public class ProductDetailsRepository(IBaseRepository _baseRepository) : IProductDetailsRepository
{
    private readonly IBaseRepository _baseRepository = _baseRepository;

    public async Task<bool> AddRangeAsync(IEnumerable<ProductDetailsEntity> productDetails, CancellationToken ct)
    {
        _baseRepository.AddRange<ProductDetailsEntity>(productDetails);
        await _baseRepository.SaveAsync(ct);

        return true;
    }

    public async Task<bool> RemoveAsync(int productDetailId, CancellationToken ct)
    {
        var productDetail = await _baseRepository.GetAll<ProductDetailsEntity>()
                    .FirstOrDefaultAsync(p => p.Id == productDetailId, ct);

        if (productDetail == null)
        {
            return false;
        }

        _baseRepository.Delete(productDetail);
        await _baseRepository.SaveAsync(ct);

        return true;
    }

    public async Task<bool> EditRangeAsync(IEnumerable<ProductDetailsEntity> productDetails, CancellationToken ct)
    {
        _baseRepository.UpdateRange<ProductDetailsEntity>(productDetails);
        await _baseRepository.SaveAsync(ct);

        return true;
    }
}