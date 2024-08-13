using ECommerceMVC.Application.Dtos.Baskets;

namespace ECommerceMVC.Application.Interfaces;

public interface IBasketService
{
    Task<int> AddAsync(AddBasketDto addBasketDto, CancellationToken ct);

    Task<IEnumerable<BasketDto>> GetAllActiveAsync(CancellationToken ct);
}
