using System;
using System.Collections.Generic;

namespace Project_1.Models;

public partial class CustomerDetail
{
    public int CustomerId { get; set; }

    public string? CustomerName { get; set; }

    public bool? CustomerIsMember { get; set; }

    public virtual ICollection<OrderDetail> OrderDetails { get; set; } = new List<OrderDetail>();
}
