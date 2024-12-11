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
            .ForMember(dest => dest.ProductSubcategoryId, opt => opt.MapFrom(src => src.ProductSubcategoryId))
            .ForMember(dest => dest.ProductDetails, opt => opt.MapFrom(src => src.ProductDetails));

        CreateMap<AddProductDto, ProductEntity>()
            .ForMember(dest => dest.Id, opt => opt.Ignore())
            .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
            .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description))
            .ForMember(dest => dest.CreateTimeUtc, opt => opt.MapFrom(src => DateTime.UtcNow))
            .ForMember(dest => dest.ImagePath, opt => opt.MapFrom(src => src.ImagePath))
            .ForMember(dest => dest.Price, opt => opt.MapFrom(src => src.Price))
            .ForMember(dest => dest.ProductSubcategoryId, opt => opt.MapFrom(src => src.ProductSubcategoryId))
            .ForMember(dest => dest.ProductDetails, opt => opt.Ignore());

        CreateMap<AddProductDetailsDto, ProductDetailsEntity>()
            .ForMember(dest => dest.IsMain, opt => opt.MapFrom(src => src.IsMain))
            .ForMember(dest => dest.Key, opt => opt.MapFrom(src => src.Key))
            .ForMember(dest => dest.Value, opt => opt.MapFrom(src => src.Value))
            .ForMember(dest => dest.CreateTimeUtc, opt => opt.MapFrom(src => DateTime.UtcNow));

        CreateMap<EditProductDto, ProductEntity>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
            .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
            .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description))
            .ForMember(dest => dest.CreateTimeUtc, opt => opt.Ignore())
            .ForMember(dest => dest.ImagePath, opt => opt.MapFrom(src => src.ImagePath))
            .ForMember(dest => dest.Price, opt => opt.MapFrom(src => src.Price))
            .ForMember(dest => dest.ProductSubcategoryId, opt => opt.MapFrom(src => src.ProductSubcategoryId));

        CreateMap<ProductDetailsEntity, ProductDetailsDto>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
            .ForMember(dest => dest.IsMain, opt => opt.MapFrom(src => src.IsMain))
            .ForMember(dest => dest.Value, opt => opt.MapFrom(src => src.Value))
            .ForMember(dest => dest.Key, opt => opt.MapFrom(src => src.Key));

        CreateMap<ProductDetailsDto, ProductDetailsEntity>()
           .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
           .ForMember(dest => dest.IsMain, opt => opt.MapFrom(src => src.IsMain))
           .ForMember(dest => dest.Value, opt => opt.MapFrom(src => src.Value))
           .ForMember(dest => dest.Key, opt => opt.MapFrom(src => src.Key));
    }
}