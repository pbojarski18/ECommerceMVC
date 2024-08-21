using ECommerceMVC.Domain.Enums;
using System.Runtime.CompilerServices;

namespace ECommerceMVC.Application.Dtos.Products;

public class GetPagedByFiltersTransferDto
{
    public int MinWeight { get; set; }

    public int MaxWeight { get; set; }

    public double MinPrice { get; set; }

    public double MaxPrice { get; set; }

    public string Name { get; set; }

    public int CurrentPage { get; set; }

    public int PageSize { get; set; }

}
