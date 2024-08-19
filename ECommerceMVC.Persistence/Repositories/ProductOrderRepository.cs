using ECommerceMVC.Domain.Entities;
using ECommerceMVC.Domain.Repositories;

namespace ECommerceMVC.Persistence.Repositories;

public class ProductOrderRepository(IBaseRepository _baseRepository) : IProductOrderRepository
{
    private readonly IBaseRepository _baseRepository = _baseRepository;

    public async Task<int> AddAsync(ProductOrderEntity productOrder, CancellationToken ct)
    {
        await _baseRepository.AddAsync(productOrder, ct);
        await _baseRepository.SaveAsync(ct);

        return productOrder.Id;
    }

    public async Task<bool> AddRangeAsync(IEnumerable<ProductOrderEntity> productOrders, CancellationToken ct)
    {
        _baseRepository.AddRange(productOrders);
        await _baseRepository.SaveAsync(ct);

        return true;
    }
}
