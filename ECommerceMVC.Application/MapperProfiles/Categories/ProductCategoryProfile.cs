using AutoMapper;
using ECommerceMVC.Application.Dtos.Categories;
using ECommerceMVC.Domain.Entities;

namespace ECommerceMVC.Application.MapperProfiles.Categories;

public class ProductCategoryProfile : Profile
{
    public ProductCategoryProfile()
    {
        CreateMap<ProductCategoryDto, ProductCategoryEntity>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
            .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
            .ForMember(dest => dest.ProductSubcategories, opt => opt.MapFrom(src => src.Subcategories));

        CreateMap<ProductCategoryEntity, ProductCategoryDto>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
            .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
            .ForMember(dest => dest.Subcategories, opt => opt.MapFrom(src => src.ProductSubcategories));
    }
}