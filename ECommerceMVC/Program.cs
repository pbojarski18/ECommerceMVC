using ECommerceMVC.Application.Interfaces;
using ECommerceMVC.Application.Services;
using ECommerceMVC.Domain.Repositories;
using ECommerceMVC.Persistence.Context;
using ECommerceMVC.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using ECommerceMVC.Application.Extensions;
using ECommerceMVC.Infrastructure.FileService;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnectionString")));
builder.Services.AddScoped<IBaseRepository, BaseRepository>();
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<IProductCategoryRepository, ProductCategoryRepository>();
builder.Services.AddScoped<IStockRepository, StockRepository>();
builder.Services.AddScoped<IStockHistoryRepository, StockHistoryRepository>();
builder.Services.AddScoped<IFileSaver, FileSaver>();
builder.Services.AddApplicationDi();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
