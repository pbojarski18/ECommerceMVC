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

    public async Task<StockEntity> GetByProductIdAsync(int productId, CancellationToken ct)
    {
        var product = await _baseRepository.GetAll<StockEntity>()
            .FirstOrDefaultAsync(p => p.ProductId == productId, ct);

        if (product == null)
        {
            throw new Exception("Stock not found");
        }
        else
        {
            return product;
        }
    }
}
