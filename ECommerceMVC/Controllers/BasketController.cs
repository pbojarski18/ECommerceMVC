using ECommerceMVC.Application.Dtos.Baskets;
using ECommerceMVC.Application.Interfaces;
using ECommerceMVC.Domain.Enums;
using Microsoft.AspNetCore.Mvc;

namespace ECommerceMVC.Controllers;

public class BasketController(IBasketService _basketService) : Controller
{
    private readonly IBasketService _basketService = _basketService;

    [HttpPost]
    public async Task<IActionResult> AddBasket(int productId, double totalCost)
    {
        var addBasketDto = new AddBasketDto { IsActive = true, ProductId = productId, ProductQuantity = 1, TotalCost = totalCost };
        var model = await _basketService.AddAsync(addBasketDto, default);

        return RedirectToAction("CustomerProduct", "Product");
    }

    [HttpGet]
    public async Task<IActionResult> Index()
    {
        var model = await _basketService.GetAllActiveAsync(default);
        return View(model);
    }
}
