using ECommerceMVC.Application.Dtos.Orders;
using ECommerceMVC.Application.Interfaces;
using ECommerceMVC.Application.Services;
using ECommerceMVC.Domain.Enums;
using Microsoft.AspNetCore.Mvc;

namespace ECommerceMVC.Controllers;

public class OrderController(IOrderService _orderService) : Controller
{
    private readonly IOrderService _orderService = _orderService;

    [HttpGet]
    public IActionResult Index(int id)
    {
        var model = new CreateOrderDto { ProductId = id };
        return View(model);
    }

    [HttpPost]
    public async Task<IActionResult> Index(CreateOrderDto createOrderDto)
    {
        var model = await _orderService.AddAsync(createOrderDto, default);
        return RedirectToAction("Index");
    }

}
