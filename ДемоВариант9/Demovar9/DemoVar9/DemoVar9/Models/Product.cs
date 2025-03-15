using System;
using System.Collections.Generic;

namespace DemoVar9.Models;

public partial class Product
{
    public string IdProduct { get; set; } = null!;

    public string Name { get; set; } = null!;

    public string Position { get; set; } = null!;

    public int Cost { get; set; }

    public int MaxDiscount { get; set; }

    public int IdManufacturer { get; set; }

    public int IdSupplier { get; set; }

    public int IdProductCategory { get; set; }

    public int CurrentDiscount { get; set; }

    public int Quantity { get; set; }

    public string Description { get; set; } = null!;

    public string Image { get; set; } = null!;

    public virtual Manufacturer IdManufacturerNavigation { get; set; } = null!;

    public virtual ProductCategory IdProductCategoryNavigation { get; set; } = null!;

    public virtual Supplier IdSupplierNavigation { get; set; } = null!;
}
