﻿using System;
using System.Collections.Generic;

namespace DemoVar9.Models;

public partial class Manufacturer
{
    public int IdManufacturer { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}
