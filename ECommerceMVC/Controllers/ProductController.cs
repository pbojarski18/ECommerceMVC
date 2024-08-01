using ECommerceMVC.Application.Dtos.Products;
using ECommerceMVC.Application.Interfaces;
using ECommerceMVC.Domain.Entities;
using ECommerceMVC.Domain.Enums;
using Microsoft.AspNetCore.Mvc;

namespace ECommerceMVC.Controllers;

public class ProductController(IProductService _productService) : Controller
{
    private readonly IProductService _productService = _productService;

    public IActionResult Index()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Index(ProductType productType)
    {
        var model = await _productService.GetAllByFiltersAsync(productType, default);
        return View(model);
    }

    public IActionResult AddProduct()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> AddProduct(ProductDto productDto)
    {
        var model = await _productService.AddAsync(productDto, default);

        return View(model);
    }
}
