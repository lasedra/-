using System;
using System.Collections.Generic;

namespace GreatBritain.Models;

public partial class Product
{
    public int Id { get; set; }

    public string Title { get; set; } = null!;

    public decimal Cost { get; set; }

    public string? Description { get; set; }

    public string? MainImagePath { get; set; }

    public bool IsActive { get; set; }

    public int? ManufacturerId { get; set; }

    public byte[]? PhotoProduct { get; set; }

    public virtual ICollection<AttachedProduct> AttachedProducts { get; set; } = new List<AttachedProduct>();

    public virtual Manufacturer? Manufacturer { get; set; }

    public virtual ICollection<ProductSale> ProductSales { get; set; } = new List<ProductSale>();
}
