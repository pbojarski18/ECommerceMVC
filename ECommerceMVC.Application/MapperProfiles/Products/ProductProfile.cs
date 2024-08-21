using AutoMapper;
using ECommerceMVC.Application.Dtos.Products;
using ECommerceMVC.Domain.Entities;

namespace ECommerceMVC.Application.MapperProfiles.Products;

public class ProductProfile : Profile
{
    public ProductProfile()
    {
        CreateMap<ProductEntity, ProductDto>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
            .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
            .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description))
            .ForMember(dest => dest.Brand, opt => opt.MapFrom(src => src.Brand))
            .ForMember(dest => dest.ImagePath, opt => opt.MapFrom(src => src.ImagePath))
            .ForMember(dest => dest.Price, opt => opt.MapFrom(src => src.Price))
            .ForMember(dest => dest.ProductQuantity, opt => opt.MapFrom(src => src.Stock.ProductQuantity))
            .ForMember(dest => dest.ProductSubcategoryId, opt => opt.MapFrom(src => src.ProductSubcategoryId));

        CreateMap<AddProductDto, ProductEntity>()
            .ForMember(dest => dest.Id, opt => opt.Ignore())
            .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
            .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description))
            .ForMember(dest => dest.CreateTimeUtc, opt => opt.MapFrom(src => DateTime.UtcNow))
            .ForMember(dest => dest.ImagePath, opt => opt.MapFrom(src => src.ImagePath))
            .ForMember(dest => dest.Price, opt => opt.MapFrom(src => src.Price))
            .ForMember(dest => dest.ProductSubcategoryId, opt => opt.MapFrom(src => src.ProductSubcategoryId));

        CreateMap<EditProductDto, ProductEntity>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
            .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
            .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description))
            .ForMember(dest => dest.CreateTimeUtc, opt => opt.MapFrom(src => DateTime.UtcNow))
            .ForMember(dest => dest.ImagePath, opt => opt.MapFrom(src => src.ImagePath))
            .ForMember(dest => dest.Price, opt => opt.MapFrom(src => src.Price))
            .ForMember(dest => dest.ProductSubcategoryId, opt => opt.MapFrom(src => src.ProductSubcategoryId));

    }
}
