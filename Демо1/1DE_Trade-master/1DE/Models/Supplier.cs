﻿using System;
using System.Collections.Generic;

namespace _1DE.Models;

public partial class Supplier
{
    public int SupplierId { get; set; }

    public string SupplierName { get; set; } = null!;

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}
