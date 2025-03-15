using System;
using System.Collections.Generic;

namespace DemoVar9.Models;

public partial class ProductCategory
{
    public int IdProductCategory { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}
