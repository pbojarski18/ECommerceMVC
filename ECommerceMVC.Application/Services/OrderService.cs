using AutoMapper;
using ECommerceMVC.Application.Abstraction;
using ECommerceMVC.Application.Dtos.Orders;
using ECommerceMVC.Application.Interfaces;
using ECommerceMVC.Domain.Entities;
using ECommerceMVC.Domain.Repositories;

namespace ECommerceMVC.Application.Services;

public class OrderService(IOrderRepository _orderRepository,
                          IMapper _mapper,
                          IProductOrderRepository _productOrderRepository,
                          IStockRepository _stockRepository,
                          IStockHistoryRepository _stockHistoryRepository,
                          IBasketRepository _basketRepository,
                          IUnitOfWork _unitOfWork) : IOrderService
{
    public async Task<int> AddAsync(CreateOrderDto createOrderDto, CancellationToken ct)
    {
        using var transaction = await _unitOfWork.BeginTransactionAsync();
        try
        {
            var orderEntity = _mapper.Map<OrderEntity>(createOrderDto);
            orderEntity.CreateTimeUtc = DateTime.UtcNow;
            orderEntity.OrderStatus = Domain.Enums.OrderStatusType.Ordered;
            await _orderRepository.AddAsync(orderEntity, ct);

            var userBaskets = await _basketRepository.GetAllActiveAsync(createOrderDto.UserId, ct);
            var productOrderEntities = new List<ProductOrderEntity>();
            foreach (var userBasket in userBaskets)
            {
                var productOrderEntity = new ProductOrderEntity()
                {
                    ProductId = userBasket.ProductId,
                    ProductQuantity = userBasket.ProductQuantity,
                    OrderId = orderEntity.Id,
                    CreateTimeUtc = DateTimeOffset.UtcNow
                };
                productOrderEntities.Add(productOrderEntity);
            }
            await _productOrderRepository.AddRangeAsync(productOrderEntities, ct);

            var stocks = await _stockRepository.GetByProductsIdsAsync(productOrderEntities.Select(p => p.ProductId).Distinct(), ct);
            var stockHistories = new List<StockHistoryEntity>();
            foreach (var stock in stocks)
            {
                stock.ProductQuantity = stock.ProductQuantity - productOrderEntities.Where(p => p.ProductId == stock.ProductId).Select(p => p.ProductQuantity).Sum();
                var stockHistory = new StockHistoryEntity
                {
                    ProductQuantity = stock.ProductQuantity,
                    ProductId = stock.ProductId,
                    StockId = stock.Id,
                    Message = $"Stock reduced by {productOrderEntities.Where(p => p.ProductId == stock.ProductId).Select(p => p.ProductQuantity).Sum()} due to order {orderEntity.Id}",
                    CreateTimeUtc = DateTime.UtcNow
                };
                stockHistories.Add(stockHistory);
            }
            await _stockRepository.UpdateRangeAsync(stocks, ct);
            await _stockHistoryRepository.AddRangeAsync(stockHistories, ct);
            await _basketRepository.DeactivateUserBasketsAsync(createOrderDto.UserId, ct);

            transaction.Commit();
            return orderEntity.Id;
        }
        catch (Exception ex)
        {
            transaction.Rollback();
            throw new Exception(ex.Message);
        }
    }
}