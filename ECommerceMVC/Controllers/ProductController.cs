using ECommerceMVC.Application.Dtos.Products;
using ECommerceMVC.Application.Interfaces;
using ECommerceMVC.Application.Validators.Product;
using ECommerceMVC.Domain.Entities;
using ECommerceMVC.Domain.Enums;
using ECommerceMVC.Infrastructure.FileService;
using ECommerceMVC.ViewModels;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;

namespace ECommerceMVC.Controllers;

[Route("Product")]
public class ProductController(IProductService _productService,
                               AddProductDtoValidator _productDtoValidator,
                               IFileSaver _fileSaver) : Controller
{
    private readonly IProductService _productService = _productService;
    private readonly AddProductDtoValidator _productDtoValidator = _productDtoValidator;
    private readonly IFileSaver _fileSaver = _fileSaver;

    [HttpGet("admin-products")]
    public async Task<IActionResult> Index()
    {
        var categories = await _productService.GetAllCategoriesAsync(default);
        var model = new CustomerProductViewModel() { ProductCategories = categories };
        return View(model);
    }

    [HttpGet("admin-get-by-id")]
    public async Task<IActionResult> Index(int Id)
    {
        var model = new CustomerProductViewModel();
        model.GetPagedByFiltersTransferDto = new GetPagedByFiltersTransferDto() { ProductSubcategoryId = Id, CurrentPage = 1, PageSize = 20 };
        model.ProductCategories = await _productService.GetAllCategoriesAsync(default);
        model.Products = await _productService.GetPagedByUserFiltersAsync(model.GetPagedByFiltersTransferDto, default);
        return View(model);
    }



    [HttpGet("customer-product")]
    public async Task<IActionResult> CustomerProduct()
    {
        var categories = await _productService.GetAllCategoriesAsync(default);
        var model = new CustomerProductViewModel() { ProductCategories = categories };
        return View(model);
    }

    [HttpGet("by-id")]
    public async Task<IActionResult> CustomerProduct(int Id)
    {
        var model = new CustomerProductViewModel();
        model.GetPagedByFiltersTransferDto = new GetPagedByFiltersTransferDto() { ProductSubcategoryId = Id, CurrentPage = 1, PageSize = 20 };
        model.ProductCategories = await _productService.GetAllCategoriesAsync(default);
        model.Products = await _productService.GetPagedByUserFiltersAsync(model.GetPagedByFiltersTransferDto, default);
        return View(model);
    }

    [HttpGet("by-filters")]
    public async Task<IActionResult> CustomerProduct(GetPagedByFiltersTransferDto filters)
    {
        var model = new CustomerProductViewModel();
        model.GetPagedByFiltersTransferDto = filters;
        model.Products = await _productService.GetPagedByUserFiltersAsync(filters, default);
        return View(model);
    }


    [HttpGet("AddProduct")]
    public async Task<IActionResult> AddProduct()
    {
        var category = await _productService.GetAllCategoriesAsync(default);
        var model = new AddProductViewModel() { Categories = category };
        return View(model);
    }

    [HttpPost("AddProduct")]
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

    [HttpPost("RemoveProduct")]
    public async Task<IActionResult> RemoveProduct(int productId)
    {
        var model = await _productService.RemoveAsync(productId, default);

        return RedirectToAction(nameof(Index));
    }

    [HttpGet("EditProduct")]
    public async Task<IActionResult> EditProduct(int id)
    {
        var product = await _productService.GetByIdAsync(id, default);
        var model = new EditProductDto(product);
        var viewModel = new EditProductViewModel();
        viewModel.EditProductDto = model;
        viewModel.Categories = await _productService.GetAllCategoriesAsync(default);
        return View(viewModel);
    }

    [HttpPost("EditProduct")]
    public async Task<IActionResult> EditProduct(EditProductDto editProductDto, IFormFile file)
    {
        //var result = await _productDtoValidator.ValidateAsync(editProductDto);
        //if (result.IsValid)
        //{
        if ((file == null || file.Length == 0) && string.IsNullOrEmpty(editProductDto.ImagePath))
        {
            ModelState.AddModelError("File", "No file uploaded.");
            return View(editProductDto);
        }
        if (file != null)
        {
            var filePath = await _fileSaver.SaveFile(file);
            // Przypisz ścieżkę obrazu do produktu
            editProductDto.ImagePath = filePath;           
        }     

        var model = await _productService.EditAsync(editProductDto, default);
        return RedirectToAction(nameof(Index));
        //}

        //return View(editProductDto);
    }

    [HttpGet("ProductDetails")]
    public async Task<IActionResult> ProductDetails(int id)
    {
        var model = await _productService.GetByIdAsync(id, default);

        return View(model);
    }

    [HttpPost("delete-by-id")]
    public async Task<IActionResult> DeleteProductDetail(int id)
    {
        var model = await _productService.RemoveDetailAsync(id, default);

        return NoContent();
    }
}
