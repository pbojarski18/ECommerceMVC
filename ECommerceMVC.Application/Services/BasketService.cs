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

    public async Task<IEnumerable<BasketDto>> GetAllActiveAsync(CancellationToken ct)
    {
        var basketEntities = await _basketRepository.GetAllActiveAsync(ct);
        var basketDto = _mapper.Map<IEnumerable<BasketDto>>(basketEntities);

        return basketDto;
    }
}
