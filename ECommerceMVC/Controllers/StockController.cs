using ECommerceMVC.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ECommerceMVC.Controllers;

public class StockController(IStockService _stockService) : Controller
{
    private readonly IStockService _stockService = _stockService;

    public async Task<IActionResult> Index(int productId)
    {
        var model = await _stockService.GetByProductIdAsync(productId, default);

        return View(model);
    }
}


