using ECommerceMVC.Application.Dtos.Products;
using ECommerceMVC.Application.Interfaces;
using ECommerceMVC.Application.Validators.Product;
using ECommerceMVC.Domain.Entities;
using ECommerceMVC.Domain.Enums;
using Microsoft.AspNetCore.Mvc;

namespace ECommerceMVC.Controllers;

public class ProductController(IProductService _productService, ProductDtoValidator _productDtoValidator) : Controller
{
    private readonly IProductService _productService = _productService;
    private readonly ProductDtoValidator _productDtoValidator = _productDtoValidator;
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

    [HttpGet]
    public async Task<IActionResult> CustomerProduct()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> CustomerProduct(GetPagedByFiltersTransferDto filters)
    {
        var model = await _productService.GetPagedByUserFiltersAsync(filters, default);
        return View(model);
    }


    [HttpGet]
    public IActionResult AddProduct()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> AddProduct(ProductDto productDto)
    {
        var result = await _productDtoValidator.ValidateAsync(productDto);
        if (result.IsValid)
        {
            var model = await _productService.AddAsync(productDto, default);
            return RedirectToAction(nameof(Index));
        }

        return View(productDto);
    }

    [HttpPost]
    public async Task<IActionResult> RemoveProduct(int productId)
    {
        var model = await _productService.RemoveAsync(productId, default);

        return RedirectToAction(nameof(Index));
    }

    [HttpGet]
    public async Task<IActionResult> EditProduct(int id)
    {
        var model = await _productService.GetByIdAsync(id, default);
        return View(model);
    }

    [HttpPost]
    public async Task<IActionResult> EditProduct(ProductDto productDto)
    {
        var result = await _productDtoValidator.ValidateAsync(productDto);
        if (result.IsValid)
        {
            var model = await _productService.EditAsync(productDto, default);
            return RedirectToAction(nameof(Index));
        }

        return View(productDto);
    }
}
