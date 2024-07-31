using ECommerceMVC.Application.Services;
using ECommerceMVC.Domain.Entities;
using ECommerceMVC.Domain.Enums;
using ECommerceMVC.Domain.Repositories;
using FluentAssertions;
using Moq;

namespace ECommerceMVC.Application.UnitTests.Services;

public class ProductServiceTests
{
    [Fact]
    public async Task GetAllByFiltersAsync_ShouldReturnMappedProducts()
    {
        //Arrange//
        var repositoryMock = new Mock<IProductRepository>();
        var products = new List<ProductEntity>()
        {
            new ProductEntity
            {
                Id = 1,
                Name = "Dodo",
                Price = 17,
                Description = "This is description",
                ImagePath = "url",
                ProductCategory = new ProductCategoryEntity()
                {
                    Brand = "Head",
                    Sex = "Male",
                    ProductType = ProductType.Bags
                }
            }

        };
        repositoryMock.Setup(x => x.GetAllByFiltersAsync(It.IsAny<ProductType>(), It.IsAny<CancellationToken>())).ReturnsAsync(products);
        var productService = new ProductService(repositoryMock.Object);

        //Act//
        var result = await productService.GetAllByFiltersAsync(ProductType.Bags, default);

        //Assert//
        result.First().Id.Should().Be(1);
        result.First().Name.Should().Be("Dodo");
        result.First().Price.Should().Be(17);
        result.First().Description.Should().Be("This is description");
        result.First().ImagePath.Should().Be("url");
        result.First().Brand.Should().Be("Head");
        result.First().Sex.Should().Be("Male");
        result.First().ProductType.Should().Be(ProductType.Bags);
    }
}

