using AutoMapper;
using ECommerceMVC.Application.Dtos.Orders;
using ECommerceMVC.Domain.Entities;

namespace ECommerceMVC.Application.MapperProfiles.Orders;

public class OrderProfile : Profile
{
    public OrderProfile()
    {
        CreateMap<CreateOrderDto, OrderEntity>()
            .ForMember(dest => dest.UserEmail, opt => opt.MapFrom(src => src.UserEmail))
            .ForMember(dest => dest.UserFirstName, opt => opt.MapFrom(src => src.UserFirstName))
            .ForMember(dest => dest.UserLastName, opt => opt.MapFrom(src => src.UserLastName))
            .ForMember(dest => dest.UserAddress, opt => opt.MapFrom(src => src.UserAddress))
            .ForMember(dest => dest.UserCity, opt => opt.MapFrom(src => src.UserCity))
            .ForMember(dest => dest.PostalCode, opt => opt.MapFrom(src => src.PostalCode))
            .ForMember(dest => dest.PhoneNumber, opt => opt.MapFrom(src => src.PhoneNumber))
            .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.UserId));
    }
}