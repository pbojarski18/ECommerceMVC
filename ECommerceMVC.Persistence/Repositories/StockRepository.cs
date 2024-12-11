using ECommerceMVC.Domain.Entities;
using ECommerceMVC.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace ECommerceMVC.Persistence.Repositories;

public class StockRepository(IBaseRepository _baseRepository) : IStockRepository
{
    private readonly IBaseRepository _baseRepository = _baseRepository;

    public async Task<int> AddAsync(StockEntity stock, CancellationToken ct)
    {
        await _baseRepository.AddAsync<StockEntity>(stock, ct);
        await _baseRepository.SaveAsync(ct);

        return stock.Id;
    }

    public async Task<StockEntity> GetByProductIdWithPagedHistoriesAsync(int productId, int currentPage, int pageSize, CancellationToken ct)
    {
        var stock = await _baseRepository.GetAll<StockEntity>().Include(s => s.StockHistories)
            .FirstOrDefaultAsync(p => p.ProductId == productId, ct);
        var stockHistories = stock.StockHistories
            .OrderByDescending(s => s.CreateTimeUtc)
            .Skip(pageSize * (currentPage - 1))
            .Take(pageSize)
            .ToList();
        stock.StockHistories = stockHistories;

        if (stock == null)
        {
            throw new Exception("Stock not found");
        }
        else
        {
            return stock;
        }
    }

    public async Task<bool> UpdateAsync(StockEntity stock, CancellationToken ct)
    {
        _baseRepository.Update<StockEntity>(stock);
        await _baseRepository.SaveAsync(ct);

        return true;
    }

    public async Task<bool> UpdateRangeAsync(IEnumerable<StockEntity> stocks, CancellationToken ct)
    {
        _baseRepository.UpdateRange(stocks);
        await _baseRepository.SaveAsync(ct);

        return true;
    }

    public async Task<StockEntity> GetByIdAsync(int stockId, CancellationToken ct)
    {
        var stock = await _baseRepository.GetAll<StockEntity>()
            .FirstOrDefaultAsync(p => p.Id == stockId, ct);

        if (stock == null)
        {
            throw new Exception("Stock not found");
        }
        else
        {
            return stock;
        }
    }

    public async Task<StockEntity> GetByProductIdAsync(int productId, CancellationToken ct)
    {
        var stock = await _baseRepository.GetAll<StockEntity>()
            .FirstOrDefaultAsync(p => p.ProductId == productId, ct);

        if (stock == null)
        {
            throw new Exception("Stock not found");
        }
        else
        {
            return stock;
        }
    }

    public async Task<IEnumerable<StockEntity>> GetByProductsIdsAsync(IEnumerable<int> productIds, CancellationToken ct)
    {
        var stocks = _baseRepository.GetAll<StockEntity>()
            .Where(p => productIds.Contains(p.ProductId));

        return await stocks.ToListAsync(ct);
    }
}