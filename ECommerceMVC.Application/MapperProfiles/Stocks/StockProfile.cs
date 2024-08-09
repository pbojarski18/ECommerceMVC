using AutoMapper;
using ECommerceMVC.Application.Dtos.Stocks;
using ECommerceMVC.Domain.Entities;

namespace ECommerceMVC.Application.MapperProfiles.Stocks;

public class StockProfile : Profile
{
    public StockProfile()
    {
        CreateMap<StockEntity, StockDto>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
            .ForMember(dest => dest.ProductQuantity, opt => opt.MapFrom(src => src.ProductQuantity))
            .ForMember(dest => dest.StockHistories, opt => opt.MapFrom(src => src.StockHistories));

        CreateMap<StockHistoryEntity, StockHistoryDto>()
            .ForMember(dest => dest.DateTime, opt => opt.MapFrom(src => src.CreateTimeUtc))
            .ForMember(dest => dest.Message, opt => opt.MapFrom(src => src.Message));
    }
}
