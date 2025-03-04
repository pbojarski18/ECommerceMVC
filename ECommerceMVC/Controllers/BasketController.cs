﻿using ECommerceMVC.Application.Dtos.Baskets;
using ECommerceMVC.Application.Interfaces;
using ECommerceMVC.Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace ECommerceMVC.Controllers;

[Authorize]
public class BasketController(IBasketService _basketService,
                              UserManager<ApplicationUser> _userManager) : Controller
{
    [HttpPost]
    public async Task<IActionResult> AddBasket(int productId, double totalCost, int productQuantity)
    {
        var userId = _userManager.GetUserId(User);
        var addBasketDto = new AddBasketDto { IsActive = true, ProductId = productId, ProductQuantity = productQuantity, TotalCost = totalCost, UserId = userId };
        var model = await _basketService.AddAsync(addBasketDto, default);

        return RedirectToAction("customer-product", "Product");
    }

    [HttpGet]
    public async Task<IActionResult> Index()
    {
        var userId = _userManager.GetUserId(User);
        var model = await _basketService.GetAllActiveAsync(userId, default);
        return View(model);
    }

    [HttpPost]
    public async Task<IActionResult> Remove(int productId)
    {
        var userId = _userManager.GetUserId(User);
        await _basketService.RemoveAsync(userId, productId, default);
        return RedirectToAction("Index");
    }
}