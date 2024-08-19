using AutoMapper;
using ECommerceMVC.Application.Dtos.Baskets;
using ECommerceMVC.Application.Dtos.Products;
using ECommerceMVC.Application.Interfaces;
using ECommerceMVC.Domain.Entities;
using ECommerceMVC.Domain.Repositories;

namespace ECommerceMVC.Application.Services;

public class BasketService(IBasketRepository _basketRepository,
                           IMapper _mapper) : IBasketService
{
    private readonly IBasketRepository _basketRepository = _basketRepository;
    private readonly IMapper _mapper = _mapper;

    public async Task<int> AddAsync(AddBasketDto addBasketDto, CancellationToken ct)
    {
        var basketEntity = _mapper.Map<BasketEntity>(addBasketDto);
        await _basketRepository.AddAsync(basketEntity, ct);

        return basketEntity.Id;
    }

    public async Task<IEnumerable<BasketDto>> GetAllActiveAsync(string userId, CancellationToken ct)
    {
        var basketEntities = await _basketRepository.GetAllActiveAsync(userId, ct);
        var basketDtos = _mapper.Map<IEnumerable<BasketDto>>(basketEntities);

        return MergeBaskets(basketDtos);
    }

    public async Task<bool> RemoveAsync (string userId, int productId, CancellationToken ct)
    {
        return await _basketRepository.DeactivateByProductIdAsync(userId ,productId, ct);
    }

    private IEnumerable<BasketDto> MergeBaskets(IEnumerable<BasketDto> baskets)
    {
        List<BasketDto> mergedBaskets = new List<BasketDto>();

        foreach (var basket in baskets)
        {
            if (!mergedBaskets.Select(p => p.Product.Id).Contains(basket.Product.Id))
            {
                mergedBaskets.Add(basket);
            }
            else
            {
                var mergedBasket = mergedBaskets.FirstOrDefault(p => p.Product.Id == basket.Product.Id);
                mergedBasket.ProductQuantity = mergedBasket.ProductQuantity + basket.ProductQuantity;
                mergedBasket.TotalCost = mergedBasket.TotalCost + basket.TotalCost;
            }
        }

        return mergedBaskets;

    }
}
