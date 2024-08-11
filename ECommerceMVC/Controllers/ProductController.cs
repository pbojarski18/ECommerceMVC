using ECommerceMVC.Application.Dtos.Products;
using ECommerceMVC.Application.Interfaces;
using ECommerceMVC.Application.Validators.Product;
using ECommerceMVC.Domain.Entities;
using ECommerceMVC.Domain.Enums;
using ECommerceMVC.Infrastructure.FileService;
using Microsoft.AspNetCore.Mvc;

namespace ECommerceMVC.Controllers;

public class ProductController(IProductService _productService, ProductDtoValidator _productDtoValidator, IFileSaver _fileSaver) : Controller
{
    private readonly IProductService _productService = _productService;
    private readonly ProductDtoValidator _productDtoValidator = _productDtoValidator;
    private readonly IFileSaver _fileSaver = _fileSaver;

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
    public async Task<IActionResult> AddProduct(ProductDto productDto, IFormFile file)
    {
        // Sprawdź, czy plik został przesłany
        if (file == null || file.Length == 0)
        {
            ModelState.AddModelError("File", "No file uploaded.");
            return View(productDto);
        }
      
            var filePath = await _fileSaver.SaveFile(file);

            // Przypisz ścieżkę obrazu do produktu
            productDto.ImagePath = filePath;

            var result = await _productDtoValidator.ValidateAsync(productDto);
            if (!result.IsValid)
            {
                return View(productDto);
            }
            // Dodaj produkt do bazy danych
            await _productService.AddAsync(productDto, default);
        

        return RedirectToAction(nameof(Index));
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
