using ECommerceMVC.Domain.Entities;
using ECommerceMVC.Domain.Repositories;

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

    public async Task<bool> EditRangeAsync(IEnumerable<ProductDetailsEntity> productDetails, CancellationToken ct)
    {
        _baseRepository.UpdateRange<ProductDetailsEntity>(productDetails);
        await _baseRepository.SaveAsync(ct);

        return true;
    }
}
