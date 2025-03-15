using System;
using System.Collections.Generic;

namespace DemoVar9.Models;

public partial class OrderPoint
{
    public int IdOrderPoint { get; set; }

    public int PostIndex { get; set; }

    public string City { get; set; } = null!;

    public string Street { get; set; } = null!;

    public string House { get; set; } = null!;

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
}
