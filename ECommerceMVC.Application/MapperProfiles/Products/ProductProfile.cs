﻿using AutoMapper;
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
            .ForMember(dest => dest.Sex, opt => opt.MapFrom(src => src.ProductCategory.Sex))
            .ForMember(dest => dest.Brand, opt => opt.MapFrom(src => src.ProductCategory.Brand))
            .ForMember(dest => dest.ImagePath, opt => opt.MapFrom(src => src.ImagePath))
            .ForMember(dest => dest.ProductType, opt => opt.MapFrom(src => src.ProductCategory.ProductType))
            .ForMember(dest => dest.Price, opt => opt.MapFrom(src => src.Price));

        CreateMap<ProductDto, ProductEntity>()
            .ForMember(dest => dest.Id, opt => opt.Ignore())
            .ForMember(dest => dest.ProductCategory, opt => opt.MapFrom(src => new ProductCategoryEntity()))
            .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
            .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description))
            .ForMember(dest => dest.ProductCategory.Sex, opt => opt.MapFrom(src => src.Sex))
            .ForMember(dest => dest.ProductCategory.Brand, opt => opt.MapFrom(src => src.Brand))
            .ForMember(dest => dest.ImagePath, opt => opt.MapFrom(src => src.ImagePath))
            .ForMember(dest => dest.ProductCategory.ProductType, opt => opt.MapFrom(src => src.ProductType))
            .ForMember(dest => dest.Price, opt => opt.MapFrom(src => src.Price));

    }
}
