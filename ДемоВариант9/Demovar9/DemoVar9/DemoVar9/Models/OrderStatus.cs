using System;
using System.Collections.Generic;

namespace DemoVar9.Models;

public partial class OrderStatus
{
    public int IdOrderStatus { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
}
