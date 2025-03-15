using System;
using System.Collections.Generic;

namespace DemoVar9.Models;

public partial class Supplier
{
    public int IdSupplier { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}
