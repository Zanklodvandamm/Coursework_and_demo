using System;
using System.Collections.Generic;

namespace _1DE.Models;

public partial class Pickuppoint
{
    public string PickupPointId { get; set; } = null!;

    public string PickupPointCity { get; set; } = null!;

    public string PickupPointStreet { get; set; } = null!;

    public int? PickupPointHome { get; set; }

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
}
