using ECommerceMVC.Domain.Entities;
using ECommerceMVC.Domain.Repositories;

namespace ECommerceMVC.Persistence.Repositories;

public class StockHistoryRepository(IBaseRepository _baseRepository) : IStockHistoryRepository
{
    private readonly IBaseRepository _baseRepository = _baseRepository;

    public async Task<int> AddAsync(StockHistoryEntity stockHistoryEntity, CancellationToken ct)
    {
        await _baseRepository.AddAsync(stockHistoryEntity, ct);
        await _baseRepository.SaveAsync(ct);

        return stockHistoryEntity.Id;
    }

    public async Task<bool> AddRangeAsync(IEnumerable<StockHistoryEntity> stockHistories, CancellationToken ct)
    {
        _baseRepository.AddRange(stockHistories);
        await _baseRepository.SaveAsync(ct);

        return true;
    }
}