using ECommerceMVC.Domain.Entities;
using ECommerceMVC.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace ECommerceMVC.Persistence.Repositories;

public class BasketRepository(IBaseRepository _baseRepository) : IBasketRepository
{
    private readonly IBaseRepository _baseRepository = _baseRepository;

    public async Task<int> AddAsync(BasketEntity basket, CancellationToken ct)
    {
        await _baseRepository.AddAsync(basket, ct);
        await _baseRepository.SaveAsync(ct);

        return basket.Id;
    }

    public async Task<bool> DeactivateByProductIdAsync(string userId, int productId, CancellationToken ct)
    {
        var baskets = await _baseRepository.GetAll<BasketEntity>()
                                           .Include(p => p.Product)
                                           .Where(p => p.ProductId == productId && p.UserId == userId && p.IsActive)
                                           .ToListAsync(ct);

        foreach (var basket in baskets)
        {
            basket.IsActive = false;

            _baseRepository.Update(basket);
        }
        await _baseRepository.SaveAsync(ct);
        return true;
    }
    public async Task<IEnumerable<BasketEntity>> GetAllActiveAsync(string userId, CancellationToken ct)
    {

        return await _baseRepository.GetAll<BasketEntity>()
                                    .Include(p => p.Product)
                                    .Where(p => p.IsActive && p.UserId == userId)
                                    .ToListAsync(ct);
    }

    public async Task<bool> DeactivateUserBasketsAsync(string userId, CancellationToken ct)
    {
        var baskets = await _baseRepository.GetAll<BasketEntity>()
                                           .Include(p => p.Product)
                                           .Where(p => p.UserId == userId && p.IsActive)
                                           .ToListAsync(ct);
        foreach(var basket in baskets)
        {
            basket.IsActive = false;

            _baseRepository.Update(basket);
        }
        await _baseRepository.SaveAsync(ct);
        return true;
    }
}
