using ECommerceMVC.Application.Dtos.Stocks;
using ECommerceMVC.Application.Interfaces;
using ECommerceMVC.Domain.Repositories;

namespace ECommerceMVC.Application.Services;

public class StockService(IStockRepository _stockRepository) : IStockService
{
    private readonly IStockRepository _stockRepository = _stockRepository;

    public async Task<StockDto> GetByProductIdAsync (int productId, CancellationToken ct)
    {
        var stock = await _stockRepository.GetByProductIdAsync (productId, ct);
        var stockDto = new StockDto { Id = stock.Id, ProductQuantity = stock.ProductQuantity };
        
        return stockDto;
    }
}
