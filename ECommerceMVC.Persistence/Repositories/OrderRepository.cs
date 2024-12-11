using ECommerceMVC.Domain.Entities;
using ECommerceMVC.Domain.Repositories;

namespace ECommerceMVC.Persistence.Repositories;

public class OrderRepository(IBaseRepository _baseRepository) : IOrderRepository
{
    private readonly IBaseRepository _baseRepository = _baseRepository;

    public async Task<int> AddAsync(OrderEntity order, CancellationToken ct)
    {
        await _baseRepository.AddAsync(order, ct);
        await _baseRepository.SaveAsync(ct);

        return order.Id;
    }
}