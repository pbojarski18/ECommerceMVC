using ECommerceMVC.Domain.Entities;

namespace ECommerceMVC.Domain.Repositories;

public interface IProductOrderRepository
{
    Task<int> AddAsync(ProductOrderEntity productOrder, CancellationToken ct);

    Task<bool> AddRangeAsync(IEnumerable<ProductOrderEntity> productOrders, CancellationToken ct);
}