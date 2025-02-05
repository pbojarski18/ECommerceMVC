using AutoMapper;
using ECommerceMVC.Application.Dtos.Orders;
using ECommerceMVC.Domain.Entities;

namespace ECommerceMVC.Application.MapperProfiles.Orders;

public class OrderProfile : Profile
{
    public OrderProfile()
    {
        CreateMap<CreateOrderDto, OrderEntity>()
            .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.UserId))
            .ForMember(dest => dest.AddressId, opt => opt.MapFrom(src => src.AddressId));
    }
}