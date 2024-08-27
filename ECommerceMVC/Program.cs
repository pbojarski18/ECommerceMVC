using ECommerceMVC.Application.Interfaces;
using ECommerceMVC.Application.Services;
using ECommerceMVC.Domain.Repositories;
using ECommerceMVC.Persistence.Context;
using ECommerceMVC.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using ECommerceMVC.Application.Extensions;
using ECommerceMVC.Infrastructure.FileService;
using Microsoft.AspNetCore.Identity;
using ECommerceMVC.Application.Abstraction;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnectionString")));

builder.Services.AddIdentity<IdentityUser, IdentityRole>(options =>
{
    options.SignIn.RequireConfirmedAccount = false;
    options.SignIn.RequireConfirmedEmail = false;

}).AddEntityFrameworkStores<ApplicationDbContext>();
builder.Services.AddScoped<IBaseRepository, BaseRepository>();
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<IProductCategoryRepository, ProductCategoryRepository>();
builder.Services.AddScoped<IStockRepository, StockRepository>();
builder.Services.AddScoped<IStockHistoryRepository, StockHistoryRepository>();
builder.Services.AddScoped<IFileSaver, FileSaver>();
builder.Services.AddScoped<IOrderRepository, OrderRepository>();
builder.Services.AddScoped<IProductOrderRepository, ProductOrderRepository>();
builder.Services.AddScoped<IBasketRepository, BasketRepository>();
builder.Services.AddScoped<IUnitOfWork, ApplicationDbContext>();
builder.Services.AddScoped<IProductDetailsRepository, ProductDetailsRepository>();
builder.Services.AddApplicationDi();
builder.Services.AddRazorPages();
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

app.UseAuthentication();

app.UseAuthorization();

app.MapRazorPages();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
