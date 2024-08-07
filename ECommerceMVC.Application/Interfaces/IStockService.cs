using ECommerceMVC.Application.Dtos.Stocks;

namespace ECommerceMVC.Application.Interfaces;

public interface IStockService
{
    Task<StockDto> GetByProductIdAsync(int productId, CancellationToken ct);
}
