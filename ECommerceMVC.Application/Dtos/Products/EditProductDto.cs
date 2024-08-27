namespace ECommerceMVC.Application.Dtos.Products;

public class EditProductDto : AddProductDto
{
    public int Id { get; set; }

    public EditProductDto()
    {

    }

    public EditProductDto(ProductDto model)
    {
        Id = model.Id;
        Name = model.Name;
        Price = model.Price;
        Brand = model.Brand;
        Description = model.Description;
        ImagePath = model.ImagePath;
        ProductSubcategoryId = model.ProductSubcategoryId;

    }
}
