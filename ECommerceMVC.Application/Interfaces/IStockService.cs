using ECommerceMVC.Application.Dtos.Stocks;

namespace ECommerceMVC.Application.Interfaces;

public interface IStockService
{
    Task<StockDto> GetByProductIdWithPagedHistoriesAsync(int productId, int currentPage, int pageSize, CancellationToken ct);

    Task<bool> UpdateAsync(StockUpdateDto stockUpdateDto, CancellationToken ct);
}