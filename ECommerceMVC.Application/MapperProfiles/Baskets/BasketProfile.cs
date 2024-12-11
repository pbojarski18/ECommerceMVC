using AutoMapper;
using ECommerceMVC.Application.Dtos.Baskets;
using ECommerceMVC.Domain.Entities;

namespace ECommerceMVC.Application.MapperProfiles.Baskets;

public class BasketProfile : Profile
{
    public BasketProfile()
    {
        CreateMap<AddBasketDto, BasketEntity>()
            .ForMember(dest => dest.ProductId, opt => opt.MapFrom(src => src.ProductId))
            .ForMember(dest => dest.ProductQuantity, opt => opt.MapFrom(src => src.ProductQuantity))
            .ForMember(dest => dest.CreateTimeUtc, opt => opt.MapFrom(src => DateTime.UtcNow))
            .ForMember(dest => dest.TotalCost, opt => opt.MapFrom(src => src.TotalCost))
            .ForMember(dest => dest.IsActive, opt => opt.MapFrom(src => src.IsActive))
            .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.UserId))
            .ForMember(dest => dest.Product, opt => opt.Ignore());

        CreateMap<BasketEntity, BasketDto>()
            .ForMember(dest => dest.Product, opt => opt.MapFrom(src => src.Product))
            .ForMember(dest => dest.TotalCost, opt => opt.MapFrom(src => src.TotalCost))
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
            .ForMember(dest => dest.ProductQuantity, opt => opt.MapFrom(src => src.ProductQuantity));
    }
}