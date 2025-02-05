namespace ECommerceMVC.Application.Dtos.Products;

public class GetPagedByFiltersTransferDto
{
    public int TotalCount { get; set; }

    public int MinWeight { get; set; }

    public int MaxWeight { get; set; }

    public double MinPrice { get; set; }

    public double MaxPrice { get; set; }

    public int CurrentPage { get; set; }

    public int PageSize { get; set; }

    public int ProductSubcategoryId { get; set; }
}