using ECommerceMVC.Application.Dtos.Products;
using ECommerceMVC.Application.Interfaces;
using ECommerceMVC.Application.Validators.Product;
using ECommerceMVC.Domain.Entities;
using ECommerceMVC.Domain.Enums;
using ECommerceMVC.Infrastructure.FileService;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;

namespace ECommerceMVC.Controllers;

public class ProductController(IProductService _productService,
                               AddProductDtoValidator _productDtoValidator,
                               IFileSaver _fileSaver) : Controller
{
    private readonly IProductService _productService = _productService;
    private readonly AddProductDtoValidator _productDtoValidator = _productDtoValidator;
    private readonly IFileSaver _fileSaver = _fileSaver;

    public async Task<IActionResult> Index()
    {
        var model = await _productService.GetAllByFiltersAsync(default);
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
    public async Task<IActionResult> AddProduct(AddProductDto addProductDto, IFormFile file)
    {
        // Sprawdź, czy plik został przesłany
        if (file == null || file.Length == 0)
        {
            ModelState.AddModelError("File", "No file uploaded.");
            return View(addProductDto);
        }
      
            var filePath = await _fileSaver.SaveFile(file);

        // Przypisz ścieżkę obrazu do produktu
        addProductDto.ImagePath = filePath;

            var result = await _productDtoValidator.ValidateAsync(addProductDto);
            if (!result.IsValid)
            {
                return View(addProductDto);
            }
            // Dodaj produkt do bazy danych
            await _productService.AddAsync(addProductDto, default);
        

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
    public async Task<IActionResult> EditProduct(EditProductDto editProductDto)
    {
        var result = await _productDtoValidator.ValidateAsync(editProductDto);
        if (result.IsValid)
        {
            var model = await _productService.EditAsync(editProductDto, default);
            return RedirectToAction(nameof(Index));
        }

        return View(editProductDto);
    }

}
