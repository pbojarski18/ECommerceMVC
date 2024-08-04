using AutoMapper;
using ECommerceMVC.Application.Dtos.Products;
using ECommerceMVC.Application.Interfaces;
using ECommerceMVC.Domain.Entities;
using ECommerceMVC.Domain.Enums;
using ECommerceMVC.Domain.Repositories;

namespace ECommerceMVC.Application.Services;

public class ProductService(IProductRepository _productRepository,
                            IMapper _mapper) : IProductService
{
    private readonly IProductRepository _productRepository = _productRepository;
    private readonly IMapper _mapper = _mapper;

    public async Task<IEnumerable<ProductDto>> GetAllByFiltersAsync(ProductType productType, CancellationToken ct)
    {
        var productEntities = await _productRepository.GetAllByFiltersAsync(productType, ct);
        var productDtos = _mapper.Map<IEnumerable<ProductDto>>(productEntities);

        return productDtos;

    }

    public async Task<int> AddAsync(ProductDto productDto, CancellationToken ct)
    {
        var productEntity = _mapper.Map<ProductEntity>(productDto);
        await _productRepository.AddAsync(productEntity, ct);

        return productEntity.Id;
    }

    public async Task<bool> RemoveAsync(int productId, CancellationToken ct)
    {
        return await _productRepository.RemoveAsync(productId, ct);
    }

}
