using ECommerceMVC.Application.Dtos.Products;
using ECommerceMVC.Domain.Enums;
using ECommerceMVC.Domain.Repositories;

namespace ECommerceMVC.Application.Services;

public class ProductService(IProductRepository _productRepository)
{
    private readonly IProductRepository _productRepository = _productRepository;

    public async Task<IEnumerable<ProductDto>> GetAllByFiltersAsync(ProductType productType, CancellationToken ct)
    {
        var productEntities = await _productRepository.GetAllByFiltersAsync(productType, ct);
        var productDtos = productEntities.Select(productEntities => new ProductDto()
        {
            Name = productEntities.Name,
            Description = productEntities.Description,
            Price = productEntities.Price,
            Sex = productEntities.ProductCategory.Sex,
            Brand = productEntities.ProductCategory.Brand,
            Id = productEntities.Id,
            ImagePath = productEntities.ImagePath,
            ProductType = productEntities.ProductCategory.ProductType

        });

        return productDtos;
    }

}
