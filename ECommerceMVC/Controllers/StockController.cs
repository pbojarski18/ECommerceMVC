using ECommerceMVC.Application.Dtos.Stocks;
using ECommerceMVC.Application.Interfaces;
using ECommerceMVC.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace ECommerceMVC.Controllers;

public class StockController(IStockService _stockService) : Controller
{
    private readonly IStockService _stockService = _stockService;

    public async Task<IActionResult> Index(int productId)
    {
        var stockDto = await _stockService.GetByProductIdWithPagedHistoriesAsync(productId, 1, 10, default);
        var model = new StockViewModel() { StockDto = stockDto, StockUpdateDto = new StockUpdateDto() { Id = stockDto.Id } };
        return View(model);
    }

    [HttpPost]
    public async Task<IActionResult> UpdateStock(StockUpdateDto stockUpdateDto)
    {
        await _stockService.UpdateAsync(stockUpdateDto, default);
        return RedirectToAction("Index", "Product");
    }
}


