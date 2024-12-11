using ECommerceMVC.Domain.Entities;

namespace ECommerceMVC.Domain.Repositories;

public interface IOrderRepository
{
    Task<int> AddAsync(OrderEntity order, CancellationToken ct);
}