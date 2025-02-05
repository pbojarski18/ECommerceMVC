using ECommerceMVC.Application.Dtos.Baskets;

namespace ECommerceMVC.Application.Interfaces;

public interface IBasketService
{
    Task<int> AddAsync(AddBasketDto addBasketDto, CancellationToken ct);

    Task RemoveAsync(string userId, int productId, CancellationToken ct);

    Task<IEnumerable<BasketDto>> GetAllActiveAsync(string userId, CancellationToken ct);
}