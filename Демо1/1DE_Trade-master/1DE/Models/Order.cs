using System;
using System.Collections.Generic;

namespace _1DE.Models;

public partial class Order
{
    public int OrderId { get; set; }

    public DateTime OrderDate { get; set; }

    public DateTime OrderDeliveryDate { get; set; }

    public string OrderPickupPointId { get; set; } = null!;

    public int OrderUserId { get; set; }

    public string OrderCode { get; set; } = null!;

    public string OrderStatus { get; set; } = null!;

    public virtual Pickuppoint OrderPickupPoint { get; set; } = null!;

    public virtual User OrderUser { get; set; } = null!;

    public virtual ICollection<Orderproduct> Orderproducts { get; set; } = new List<Orderproduct>();
    public bool IsAllInStock
    {
        get
        {
            // Если Orderproducts равна null или пуста, то false
            if (Orderproducts == null || !Orderproducts.Any())
                return false;

            return Orderproducts.All(op =>
                op.ProductArticleNumberNavigation != null &&
                op.ProductArticleNumberNavigation.ProductQuantityInStock > 3);
        }
    }
    public decimal TotalOrderSum
    {
        get
        {
            return Orderproducts.Sum(op => op.TotalSum);
        }
    }
    public int TotalOrderDiscount
    {
        get
        {
            return Orderproducts.Sum(op => op.TotalDiscount);
        }
    }
}
