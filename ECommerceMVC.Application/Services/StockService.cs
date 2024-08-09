using AutoMapper;
using ECommerceMVC.Application.Dtos.Stocks;
using ECommerceMVC.Application.Interfaces;
using ECommerceMVC.Domain.Entities;
using ECommerceMVC.Domain.Repositories;

namespace ECommerceMVC.Application.Services;

public class StockService(IStockRepository _stockRepository,
                          IMapper _mapper,
                          IStockHistoryRepository _stockHistoryRepository) : IStockService
{
    private readonly IStockRepository _stockRepository = _stockRepository;
    private readonly IMapper _mapper = _mapper;
    private readonly IStockHistoryRepository _stockHistoryRepository = _stockHistoryRepository;

    public async Task<StockDto> GetByProductIdWithPagedHistoriesAsync(int productId, int currentPage, int pageSize, CancellationToken ct)
    {
        var stock = await _stockRepository.GetByProductIdWithPagedHistoriesAsync(productId, currentPage, pageSize, ct);
        var stockDto = _mapper.Map<StockDto>(stock);

        return stockDto;
    }

    public async Task<bool> UpdateAsync(StockUpdateDto stockUpdateDto, CancellationToken ct)
    {
        var stock = await _stockRepository.GetByIdAsync(stockUpdateDto.Id, ct);
        stock.ProductQuantity += stockUpdateDto.ProductQuantity;
        await _stockRepository.UpdateAsync(stock, ct);
        string message = "";
        if (stockUpdateDto.ProductQuantity > 0)
        {
            message = $"Quantity has been increased by {stockUpdateDto.ProductQuantity}";
        }
        else
        {
            message = $"Quantity has been decreased by {stockUpdateDto.ProductQuantity.ToString().Substring(1)}";
        }
        var stockHistory = new StockHistoryEntity { ProductQuantity = stock.ProductQuantity, CreateTimeUtc = DateTime.UtcNow, ProductId = stock.ProductId, StockId = stock.Id, Message = message };
        await _stockHistoryRepository.AddAsync(stockHistory, ct);
        return true;
    }
}
