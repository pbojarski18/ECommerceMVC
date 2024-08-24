using AutoMapper;
using ECommerceMVC.Application.Dtos.Categories;
using ECommerceMVC.Domain.Entities;

namespace ECommerceMVC.Application.MapperProfiles.Categories;

public class ProductSubcategoryProfile : Profile
{
    public ProductSubcategoryProfile()
    {
        CreateMap<ProductSubcategoryEntity, ProductSubcategoryDto>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
            .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name));     
    }
}
