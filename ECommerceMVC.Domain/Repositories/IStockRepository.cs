using ECommerceMVC.Domain.Entities;

namespace ECommerceMVC.Domain.Repositories;

public interface IStockRepository
{
    Task<int> AddAsync(StockEntity stock, CancellationToken ct);

    Task<StockEntity> GetByProductIdWithPagedHistoriesAsync(int productId, int currentPage, int pageSize, CancellationToken ct);

    Task<bool> UpdateAsync(StockEntity stock, CancellationToken ct);

    Task<StockEntity> GetByIdAsync(int stockId, CancellationToken ct);

    Task<StockEntity> GetByProductIdAsync(int productId, CancellationToken ct);

    Task<IEnumerable<StockEntity>> GetByProductsIdsAsync(IEnumerable<int> productIds, CancellationToken ct);

    Task<bool> UpdateRangeAsync(IEnumerable<StockEntity> stocks, CancellationToken ct);
}
