using System;
using System.Collections.Generic;

namespace DemoVar9.Models;

public partial class Order
{
    public int IdOrder { get; set; }

    public string ProductInOrder { get; set; } = null!;

    public DateOnly DateOrder { get; set; }

    public DateOnly DateDelivery { get; set; }

    public int IdOrderPoint { get; set; }

    public int IdUser { get; set; }

    public int Code { get; set; }

    public int IdStatus { get; set; }

    public virtual OrderPoint IdOrderPointNavigation { get; set; } = null!;

    public virtual OrderStatus IdStatusNavigation { get; set; } = null!;

    public virtual User IdUserNavigation { get; set; } = null!;
}
