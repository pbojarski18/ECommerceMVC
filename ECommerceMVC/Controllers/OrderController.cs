using ECommerceMVC.Application.Dtos.Addresses;
using ECommerceMVC.Application.Dtos.Orders;
using ECommerceMVC.Application.Interfaces;
using ECommerceMVC.Application.Validators.Order;
using ECommerceMVC.Domain.Entities;
using ECommerceMVC.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace ECommerceMVC.Controllers;

public class OrderController(IOrderService _orderService,
                             UserManager<ApplicationUser> _userManager,
                             CreateOrderDtoValidator _createOrderDtoValidator,
                             IAddressService _addressService) : Controller
{
    [HttpGet]
    public async Task<IActionResult> Index(string userId)
    {
        var user = await _userManager.GetUserAsync(User);
        var lastUserAddress = await _addressService.GetLastUsedByUserIdAsync(user.Id, default);

        var model = new OrderViewModel()
        {
            User = user,
            City = lastUserAddress.City,
            Country = lastUserAddress.Country,
            Street = lastUserAddress.Street,
            PostalCode = lastUserAddress.PostalCode,
            BuildingNumber = lastUserAddress.BuildingNumber,
            ApartmentNumber = lastUserAddress.ApartmentNumber
        };
        return View(model);
    }

    [HttpPost]
    public async Task<IActionResult> Index(OrderViewModel orderViewModel)
    {
        var addressId = await _addressService.GetOrCreateAsync(new AddressDto()
        {
            UserId = orderViewModel.User.Id,
            City = orderViewModel.City,
            Country = orderViewModel.Country,
            Street = orderViewModel.Street,
            PostalCode = orderViewModel.PostalCode,
            BuildingNumber = orderViewModel.BuildingNumber,
            ApartmentNumber = orderViewModel.ApartmentNumber
        }, default);

        var user = await _userManager.GetUserAsync(User);
        user.FirstName = orderViewModel.User.FirstName;
        user.LastName = orderViewModel.User.LastName;
        user.PhoneNumber = orderViewModel.User.PhoneNumber;
        user.Email = orderViewModel.User.Email;
        await _userManager.UpdateAsync(user);

        var createOrderDto = new CreateOrderDto()
        {
            UserId = orderViewModel.User.Id,
            AddressId = addressId,
        };
        await _orderService.AddAsync(createOrderDto, default);
        return RedirectToAction(nameof(Index));
    }
}