using System;
using System.Collections.Generic;

namespace Project_1.Models;

public partial class StockDetail
{
    public int StockId { get; set; }

    public int? StockStoreId { get; set; }

    public string? StockProductName { get; set; }

    public int? StockQuantity { get; set; }

    public virtual ProductDetail? StockProductNameNavigation { get; set; }

    public virtual StoreDetail? StockStore { get; set; }
}
