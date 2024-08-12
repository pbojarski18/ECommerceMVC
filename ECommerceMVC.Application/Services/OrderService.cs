using AutoMapper;
using ECommerceMVC.Application.Dtos.Orders;
using ECommerceMVC.Application.Interfaces;
using ECommerceMVC.Domain.Entities;
using ECommerceMVC.Domain.Repositories;

namespace ECommerceMVC.Application.Services;

public class OrderService(IOrderRepository _orderRepository,
                            IMapper _mapper,
                            IProductOrderRepository _productOrderRepository,
                            IStockRepository _stockRepository,
                            IStockHistoryRepository _stockHistoryRepository) : IOrderService
{
    private readonly IMapper _mapper = _mapper;
    private readonly IOrderRepository _orderRepository = _orderRepository;
    private readonly IProductOrderRepository _productOrderRepository = _productOrderRepository;
    private readonly IStockRepository _stockRepository = _stockRepository;
    private readonly IStockHistoryRepository _stockHistoryRepository = _stockHistoryRepository;

    public async Task<int> AddAsync(CreateOrderDto createOrderDto, CancellationToken ct)
    {
        var orderEntity = _mapper.Map<OrderEntity>(createOrderDto);
        orderEntity.CreateTimeUtc = DateTime.UtcNow;
        orderEntity.OrderStatus = Domain.Enums.OrderStatusType.Ordered;
        await _orderRepository.AddAsync(orderEntity, ct);

        var productOrderEntity = new ProductOrderEntity { OrderId = orderEntity.Id, ProductId = createOrderDto.ProductId };
        await _productOrderRepository.AddAsync(productOrderEntity, ct);

        var stock = await _stockRepository.GetByProductIdAsync(createOrderDto.ProductId, ct);
        stock.ProductQuantity = stock.ProductQuantity - 1;
        await _stockRepository.UpdateAsync(stock, ct);

        var stockHistory = new StockHistoryEntity { ProductQuantity = stock.ProductQuantity, ProductId = stock.ProductId, StockId = stock.Id, Message = $"Stock reduced by 1 due to order {orderEntity.Id}", CreateTimeUtc = DateTime.UtcNow };
        await _stockHistoryRepository.AddAsync(stockHistory, ct);

        return orderEntity.Id;
    }
}
