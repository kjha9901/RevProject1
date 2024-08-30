using System;
using System.Collections.Generic;

namespace Project_1.Models;

public partial class StoreDetail
{
    public int StoreId { get; set; }

    public string? StoreName { get; set; }

    public string? StoreCity { get; set; }

    public virtual ICollection<OrderDetail> OrderDetails { get; set; } = new List<OrderDetail>();

    public virtual ICollection<StockDetail> StockDetails { get; set; } = new List<StockDetail>();
}
