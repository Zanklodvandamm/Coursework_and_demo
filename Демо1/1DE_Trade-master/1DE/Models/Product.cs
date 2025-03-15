using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace _1DE.Models;

public partial class Product
{
    public string ProductArticleNumber { get; set; } = null!;

    public string ProductName { get; set; } = null!;

    public string ProductDescription { get; set; } = null!;

    public int ProductCategoryId { get; set; }

    public string? ProductPhoto { get; set; }

    [NotMapped]
    public string DisplayedImage => $"/Resources/{ProductPhoto = (ProductPhoto == null ? "picture.png" : ProductPhoto)}";

    public int ProductManufacturerId { get; set; }

    public int ProductSupplierId { get; set; }

    public decimal ProductCost { get; set; }

    public sbyte? ProductCurrentDiscount { get; set; }

    public int ProductQuantityInStock { get; set; }

    public string ProductUnit { get; set; } = null!;

    public string ProductMaxDiscountAmount { get; set; } = null!;

    public virtual ICollection<Orderproduct> Orderproducts { get; set; } = new List<Orderproduct>();

    public virtual Category ProductCategory { get; set; } = null!;

    public virtual Manufacturer ProductManufacturer { get; set; } = null!;

    public virtual Supplier ProductSupplier { get; set; } = null!;
}
