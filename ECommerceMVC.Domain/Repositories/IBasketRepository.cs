using ECommerceMVC.Domain.Entities;

namespace ECommerceMVC.Domain.Repositories;

public interface IBasketRepository
{
    Task<int> AddAsync(BasketEntity basket, CancellationToken ct);

    Task DeactivateByProductIdAsync(string userId, int productId, CancellationToken ct);

    Task<IEnumerable<BasketEntity>> GetAllActiveAsync(string userId, CancellationToken ct);

    Task DeactivateUserBasketsAsync(string userId, CancellationToken ct);
}