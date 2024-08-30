using System;
using System.Collections.Generic;

namespace Project_1.Models;

public partial class ProductDetail
{
    public int ProductId { get; set; }

    public string ProductName { get; set; } = null!;

    public string? ProductCategory { get; set; }

    public decimal? ProductPrice { get; set; }

    public string? ProductImage { get; set; }

    public virtual ICollection<OrderDetail> OrderDetails { get; set; } = new List<OrderDetail>();

    public virtual ICollection<StockDetail> StockDetails { get; set; } = new List<StockDetail>();
}
