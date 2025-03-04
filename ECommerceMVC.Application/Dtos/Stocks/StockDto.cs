﻿namespace ECommerceMVC.Application.Dtos.Stocks;

public class StockDto
{
    public int ProductQuantity { get; set; }

    public int Id { get; set; }

    public IEnumerable<StockHistoryDto> StockHistories { get; set; } = [];
}