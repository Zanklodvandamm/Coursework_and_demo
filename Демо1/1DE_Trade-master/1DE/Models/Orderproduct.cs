using System;
using System.Collections.Generic;

namespace _1DE.Models;

public partial class Orderproduct
{
    public int OrderId { get; set; }

    public string ProductArticleNumber { get; set; } = null!;

    public int ProductQuantity { get; set; }

    public virtual Order Order { get; set; } = null!;

    public virtual Product ProductArticleNumberNavigation { get; set; } = null!;

    public decimal TotalSum
    {
        get
        {
            return ProductArticleNumberNavigation.ProductCost * ProductQuantity;
        }
    }
    public int TotalDiscount
    {
        get
        {
            return Convert.ToInt32(ProductArticleNumberNavigation.ProductCurrentDiscount);
        }
    }
}
