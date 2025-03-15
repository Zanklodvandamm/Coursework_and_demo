using System;
using System.Collections.Generic;

namespace DemoWPF.Models;

public partial class Partnerproduct
{
    public int PartnerProductId { get; set; }

    public int? PartnerId { get; set; }

    public int? ProductId { get; set; }

    public int Quantity { get; set; }

    public DateTime SaleDate { get; set; }

    public virtual Partner? Partner { get; set; }

    public virtual Product? Product { get; set; }
}
