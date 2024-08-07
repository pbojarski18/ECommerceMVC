using ECommerceMVC.Domain.Entities;

namespace ECommerceMVC.Domain.Repositories;

public interface IStockRepository
{
    Task<int> AddAsync(StockEntity stock, CancellationToken ct);

    Task<StockEntity> GetByProductIdAsync(int productId, CancellationToken ct);
}
