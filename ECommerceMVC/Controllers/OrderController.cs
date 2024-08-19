using ECommerceMVC.Application.Dtos.Orders;
using ECommerceMVC.Application.Interfaces;
using ECommerceMVC.Application.Services;
using ECommerceMVC.Domain.Enums;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace ECommerceMVC.Controllers;

public class OrderController(IOrderService _orderService,
                             UserManager<IdentityUser> _userManager) : Controller
{
    private readonly IOrderService _orderService = _orderService;
    private readonly UserManager<IdentityUser> _userManager = _userManager;

    [HttpGet]
    public IActionResult Index(string userId)
    {
        userId = _userManager.GetUserId(User);
        var model = new CreateOrderDto { UserId = userId };
        return View(model);
    }

    [HttpPost]
    public async Task<IActionResult> Index(CreateOrderDto createOrderDto)
    {
        var model = await _orderService.AddAsync(createOrderDto, default);
        return RedirectToAction("Index");
    }

}
