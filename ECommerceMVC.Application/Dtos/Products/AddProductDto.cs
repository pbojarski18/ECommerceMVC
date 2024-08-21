namespace ECommerceMVC.Application.Dtos.Products;

public class AddProductDto
{
    public string Name { get; set; }

    public double Price { get; set; }

    public string Brand { get; set; }


    public string Description { get; set; }

    public string ImagePath { get; set; }

    public int ProductSubcategoryId { get; set; }
}
