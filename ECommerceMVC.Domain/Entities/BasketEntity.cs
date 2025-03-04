﻿using ECommerceMVC.Domain.Entities.Common;

namespace ECommerceMVC.Domain.Entities;

public class BasketEntity : AuditableEntity
{
    public string UserId { get; set; }

    public int ProductId { get; set; }

    public int ProductQuantity { get; set; }

    public double TotalCost { get; set; }

    public bool IsActive { get; set; }

    public virtual ProductEntity Product { get; set; }

    public virtual ApplicationUser User { get; set; }
}