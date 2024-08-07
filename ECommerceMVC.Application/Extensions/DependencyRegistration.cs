using ECommerceMVC.Application.Interfaces;
using ECommerceMVC.Application.Services;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace ECommerceMVC.Application.Extensions;

public static class DependencyRegistration
{
    public static IServiceCollection AddApplicationDi(this IServiceCollection services)
    {
        services.AddAutoMapper(Assembly.GetExecutingAssembly());
        services.AddScoped<IProductService, ProductService>();
        services.AddFluentValidationAutoValidation();
        services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
        services.AddScoped<IStockService, StockService>();
        return services;
    }


}
