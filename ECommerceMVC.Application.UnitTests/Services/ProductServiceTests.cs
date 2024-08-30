using AutoMapper;
using ECommerceMVC.Application.Dtos.Products;
using ECommerceMVC.Application.Services;
using ECommerceMVC.Application.UnitTests.MapperProfiles;
using ECommerceMVC.Domain.Entities;
using ECommerceMVC.Domain.Enums;
using ECommerceMVC.Domain.Repositories;
using FluentAssertions;
using Moq;
using System.Data;

namespace ECommerceMVC.Application.UnitTests.Services;

public class ProductServiceTests : IClassFixture<MappingTestFixture>
{
    private readonly IMapper mapper;
    private readonly Mock<IProductRepository> productRepositoryMock = new Mock<IProductRepository>();
    private readonly Mock<IProductCategoryRepository> productCategoryRepositoryMock = new Mock<IProductCategoryRepository>();
    private readonly Mock<IStockRepository> stockRepositoryMock = new Mock<IStockRepository>();
    private readonly Mock<IStockHistoryRepository> stockHistoryRepositoryMock = new Mock<IStockHistoryRepository>();
    private readonly Mock<IProductDetailsRepository> productDetailsRepositoryMock = new Mock<IProductDetailsRepository>();
    private readonly Mock<Abstraction.IUnitOfWork> unitOfWorkMock = new Mock<Abstraction.IUnitOfWork>();
    public ProductServiceTests(MappingTestFixture fixture)
    {
        mapper = fixture.mapper;
    }
    [Fact]
    public async Task GetAllByFiltersAsync_ShouldReturnMappedProducts()
    {
        //Arrange//        
        var products = new List<ProductEntity>()
        {
            new ProductEntity
            {
                Id = 1,
                Name = "Dodo",
                Price = 17,
                Description = "This is description",
                ImagePath = "url",
                Brand = "Head",
                ProductSubcategoryId = 1                
            }

        };
        productRepositoryMock.Setup(x => x.GetAllByFiltersAsync(It.IsAny<CancellationToken>())).ReturnsAsync(products);


        var productService = new ProductService(productRepositoryMock.Object, mapper, productCategoryRepositoryMock.Object, stockRepositoryMock.Object, stockHistoryRepositoryMock.Object, unitOfWorkMock.Object, productDetailsRepositoryMock.Object);

        //Act//
        var result = await productService.GetAllByFiltersAsync(default);

        //Assert//
        result.First().Id.Should().Be(1);
        result.First().Name.Should().Be("Dodo");
        result.First().Price.Should().Be(17);
        result.First().Description.Should().Be("This is description");
        result.First().ImagePath.Should().Be("url");
        result.First().Brand.Should().Be("Head");       
    }

    [Fact]

    public async Task GetPagedByUserFiltersAsync_ShouldReturnMappedProducts()
    {
        //Arrange
        var products = new List<ProductEntity>()
        {
            new ProductEntity
            {
                Id = 1,
                Name = "Dodo",
                Price = 17,
                Description = "This is description",
                ImagePath = "url",
                Brand = "Head",
                ProductSubcategoryId = 1
            }
        };

        var filters = new GetPagedByFiltersTransferDto
        {

        };
        productRepositoryMock.Setup(x => x.GetPagedByUserFiltersAsync(It.IsAny<GetPagedByFiltersTransferDto>(), It.IsAny<CancellationToken>())).ReturnsAsync(products);

        var productService = new ProductService(productRepositoryMock.Object, mapper, productCategoryRepositoryMock.Object, stockRepositoryMock.Object, stockHistoryRepositoryMock.Object, unitOfWorkMock.Object, productDetailsRepositoryMock.Object);

        //Act//
        var result = await productService.GetPagedByUserFiltersAsync(filters, default);

        //Assert//
        result.First().Id.Should().Be(1);
        result.First().Name.Should().Be("Dodo");
        result.First().Price.Should().Be(17);
        result.First().Description.Should().Be("This is description");
        result.First().ImagePath.Should().Be("url");
        result.First().Brand.Should().Be("Head");
    }

    [Fact]

    public async Task AddAsync_ShouldAddProduct()
    {
        //Arrange
        var product = new AddProductDto()

        {
            Name = "Dodo",
            Price = 17,
            Description = "This is description",
            ImagePath = "url",
            Brand = "Head",
            ProductSubcategoryId = 1
        };
        

        var transactionMock = new Mock<IDbTransaction>();

        unitOfWorkMock.Setup(x => x.BeginTransactionAsync()).ReturnsAsync(transactionMock.Object);
        productRepositoryMock.Setup(x => x.AddAsync(It.IsAny<ProductEntity>(), It.IsAny<CancellationToken>()));
        productDetailsRepositoryMock.Setup(x => x.AddRangeAsync(It.IsAny<IEnumerable<ProductDetailsEntity>>(), It.IsAny<CancellationToken>()));
        stockRepositoryMock.Setup(x => x.AddAsync(It.IsAny<StockEntity>(), It.IsAny<CancellationToken>()));
        stockHistoryRepositoryMock.Setup(x => x.AddAsync(It.IsAny<StockHistoryEntity>(), It.IsAny<CancellationToken>()));
        transactionMock.Setup(x => x.Commit());

        var productService = new ProductService(productRepositoryMock.Object, mapper, productCategoryRepositoryMock.Object, stockRepositoryMock.Object, stockHistoryRepositoryMock.Object, unitOfWorkMock.Object, productDetailsRepositoryMock.Object);

        //Act
        var result = await productService.AddAsync(product, default);

        //Assert//
        transactionMock.Verify(x => x.Commit(), Times.Once);
       
    }
}
    //public async Task RemoveAsync_ShouldRemoveProduct()
    //{
    //    //Arrange      
    //    repositoryMock.Setup(x => x.RemoveAsync(It.IsAny<int>(), It.IsAny<CancellationToken>())).ReturnsAsync(true);

    //    var productService = new ProductService(repositoryMock.Object, mapper);

    //    //Act
    //    var result = await productService.RemoveAsync(1, default);

    //    //Assert
    //    result.Should().BeTrue();
    //}


