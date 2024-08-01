using ECommerceMVC.Application.Interfaces;
using ECommerceMVC.Application.Services;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace ECommerceMVC.Application.Extensions;

public static class DependencyRegistration
{
    public static IServiceCollection AddApplicationDi (this IServiceCollection services)
    {
        services.AddAutoMapper(Assembly.GetExecutingAssembly());
        services.AddScoped<IProductService, ProductService>();
        return services;
    }

}
