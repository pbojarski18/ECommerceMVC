using ECommerceMVC.Application.Dtos.Orders;

namespace ECommerceMVC.Application.Interfaces;

public interface IOrderService
{
    Task<int> AddAsync(CreateOrderDto createOrderDto, CancellationToken ct);
}
