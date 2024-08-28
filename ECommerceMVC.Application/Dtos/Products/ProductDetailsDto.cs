using ECommerceMVC.Domain.Entities;

namespace ECommerceMVC.Application.Dtos.Products;

public class ProductDetailsDto
{
    public int Id { get; set; }

    public string Key { get; set; } = string.Empty;

    public string Value { get; set; } = string.Empty;

    public bool IsMain { get; set; }
    
}
