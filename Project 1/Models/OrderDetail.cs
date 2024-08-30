using System;
using System.Collections.Generic;

namespace Project_1.Models;

public partial class OrderDetail
{
    public int OrderId { get; set; }

    public int? OrderCustomerId { get; set; }

    public int? OrderProductId { get; set; }

    public int? OrderQuantity { get; set; }

    public int? OrderFromStore { get; set; }

    public bool? OrderFastShipping { get; set; }

    public virtual CustomerDetail? OrderCustomer { get; set; }

    public virtual StoreDetail? OrderFromStoreNavigation { get; set; }

    public virtual ProductDetail? OrderProduct { get; set; }
}
