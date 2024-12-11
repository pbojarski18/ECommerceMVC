namespace ECommerceMVC.Application.Dtos.Products;

public class AddProductDetailsDto
{
    public string Key { get; set; } = string.Empty;

    public string Value { get; set; } = string.Empty;

    public bool IsMain { get; set; }
}