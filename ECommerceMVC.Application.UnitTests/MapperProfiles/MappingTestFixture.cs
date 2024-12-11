using AutoMapper;
using ECommerceMVC.Application.MapperProfiles.Categories;
using ECommerceMVC.Application.MapperProfiles.Products;

namespace ECommerceMVC.Application.UnitTests.MapperProfiles;

public class MappingTestFixture
{
    public IConfigurationProvider configurationProvider { get; set; }

    public IMapper mapper { get; set; }

    public MappingTestFixture()
    {
        configurationProvider = new MapperConfiguration(cfg =>
        {
            cfg.AddProfile<ProductProfile>();
            cfg.AddProfile<ProductCategoryProfile>();
        });
        mapper = configurationProvider.CreateMapper();
    }
}