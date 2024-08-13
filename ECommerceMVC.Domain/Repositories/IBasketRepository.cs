using ECommerceMVC.Domain.Entities;

namespace ECommerceMVC.Domain.Repositories;

public interface IBasketRepository
{
    Task<int> AddAsync(BasketEntity basket, CancellationToken ct);

    Task<IEnumerable<BasketEntity>> GetAllActiveAsync(CancellationToken ct);
}
