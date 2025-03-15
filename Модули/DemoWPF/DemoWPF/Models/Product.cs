using System;
using System.Collections.Generic;

namespace DemoWPF.Models;

public partial class Product
{
    public int ProductId { get; set; }

    public int? ProductTypeId { get; set; }

    public string ProductName { get; set; } = null!;

    public string ProductArticle { get; set; } = null!;

    public decimal MinPartnerPrice { get; set; }

    public virtual ICollection<Partnerproduct> Partnerproducts { get; set; } = new List<Partnerproduct>();

    public virtual Producttype? ProductType { get; set; }
}
