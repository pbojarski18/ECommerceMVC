using ECommerceMVC.Domain.Entities;

namespace ECommerceMVC.Domain.Repositories;

public interface IStockHistoryRepository
{
    Task<int> AddAsync(StockHistoryEntity stockHistoryEntity, CancellationToken ct);

    Task<bool> AddRangeAsync(IEnumerable<StockHistoryEntity> stockHistories, CancellationToken ct);
}