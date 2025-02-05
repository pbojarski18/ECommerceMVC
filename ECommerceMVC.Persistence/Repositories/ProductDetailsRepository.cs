using ECommerceMVC.Domain.Entities;
using ECommerceMVC.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace ECommerceMVC.Persistence.Repositories;

public class ProductDetailsRepository(IBaseRepository _baseRepository) : IProductDetailsRepository
{
    private readonly IBaseRepository _baseRepository = _baseRepository;

    public async Task AddRangeAsync(IEnumerable<ProductDetailsEntity> productDetails, CancellationToken ct)
    {
        _baseRepository.AddRange<ProductDetailsEntity>(productDetails);
        await _baseRepository.SaveAsync(ct);
    }

    public async Task RemoveAsync(int productDetailId, CancellationToken ct)
    {
        var productDetail = await _baseRepository.GetAll<ProductDetailsEntity>()
                    .FirstOrDefaultAsync(p => p.Id == productDetailId, ct);

        if (productDetail == null)
        {
            throw new Exception("Product detail not found");
        }

        _baseRepository.Delete(productDetail);
        await _baseRepository.SaveAsync(ct);
    }

    public async Task EditRangeAsync(IEnumerable<ProductDetailsEntity> productDetails, CancellationToken ct)
    {
        _baseRepository.UpdateRange<ProductDetailsEntity>(productDetails);
        await _baseRepository.SaveAsync(ct);
    }
}