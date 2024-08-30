using System;
using System.Collections.Generic;

namespace Project_1.Models;

public partial class Product
{
    public int ProductId { get; set; }

    public string? ProductName { get; set; }

    public string? ProductCategory { get; set; }

    public decimal? ProductPrice { get; set; }

    public byte[]? ProductImage { get; set; }
}
