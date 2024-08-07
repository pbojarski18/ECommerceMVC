using AutoMapper;
using ECommerceMVC.Application.Dtos.Products;
using ECommerceMVC.Application.Interfaces;
using ECommerceMVC.Domain.Entities;
using ECommerceMVC.Domain.Enums;
using ECommerceMVC.Domain.Repositories;

namespace ECommerceMVC.Application.Services;

public class ProductService(IProductRepository _productRepository,
                            IMapper _mapper,
                            IProductCategoryRepository _productCategoryRepository,
                            IStockRepository _stockRepository) : IProductService
{
    private readonly IProductRepository _productRepository = _productRepository;
    private readonly IMapper _mapper = _mapper;
    private readonly IProductCategoryRepository _productCategoryRepository = _productCategoryRepository;
    private readonly IStockRepository _stockRepository = _stockRepository;
    public async Task<IEnumerable<ProductDto>> GetAllByFiltersAsync(ProductType productType, CancellationToken ct)
    {
        var productEntities = await _productRepository.GetAllByFiltersAsync(productType, ct);
        var productDtos = _mapper.Map<IEnumerable<ProductDto>>(productEntities);

        return productDtos;

    }

    public async Task<int> AddAsync(ProductDto productDto, CancellationToken ct)
    {
        var productEntity = _mapper.Map<ProductEntity>(productDto);
        var productCategory = await _productCategoryRepository.GetByPropertiesAsync(productDto.Brand, productDto.Sex, productDto.ProductType, ct);

        if (productCategory.Id != 0)
        {
            productEntity.ProductCategoryId = productCategory.Id;
            productEntity.ProductCategory = null;
        }
        else
        {
            productEntity.ProductCategory = new ProductCategoryEntity { Brand = productDto.Brand, Sex = productDto.Sex, ProductType = productDto.ProductType };
        }

        await _productRepository.AddAsync(productEntity, ct);
        var stockEntity = new StockEntity { ProductQuantity = 0, CreateTimeUtc = DateTime.UtcNow, ProductId = productEntity.Id};
        await _stockRepository.AddAsync(stockEntity, ct);

        return productEntity.Id;
    }

    public async Task<bool> RemoveAsync(int productId, CancellationToken ct)
    {
        return await _productRepository.RemoveAsync(productId, ct);
    }

    public async Task<bool> EditAsync(ProductDto productDto, CancellationToken ct)
    {
        
        var editedProduct = _mapper.Map<ProductEntity>(productDto);
        editedProduct.Id = productDto.Id;
        var productCategory = await _productCategoryRepository.GetByPropertiesAsync(productDto.Brand, productDto.Sex, productDto.ProductType, ct);

        if (productCategory.Id != 0)
        {
            editedProduct.ProductCategoryId = productCategory.Id;
            editedProduct.ProductCategory = null;
        }
        else
        {
            editedProduct.ProductCategory = new ProductCategoryEntity { Brand = productDto.Brand, Sex = productDto.Sex, ProductType = productDto.ProductType };
        }

        return await _productRepository.EditAsync(editedProduct, ct);
    }

    public async Task<ProductDto> GetByIdAsync(int productId, CancellationToken ct)
    {
        var product = await _productRepository.GetByIdAsync(productId, ct);
        var productDto = _mapper.Map<ProductDto>(product);

        return productDto;

    }


}
