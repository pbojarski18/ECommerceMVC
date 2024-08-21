using ECommerceMVC.Domain.Entities;
using ECommerceMVC.Domain.Enums;
using ECommerceMVC.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace ECommerceMVC.Persistence.Repositories;

public class ProductCategoryRepository(IBaseRepository _baseRepository) : IProductCategoryRepository
{
    private readonly IBaseRepository _baseRepository = _baseRepository;

    
}
