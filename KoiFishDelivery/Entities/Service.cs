using System;
using System.Collections.Generic;

namespace KoiFishDelivery.Entities;

public partial class Service
{
    public string ServiceId { get; set; } = null!;

    public string? Name { get; set; }

    public string? Description { get; set; }

    public string? PriceId { get; set; }

    public virtual ICollection<OrderService> OrderServices { get; set; } = new List<OrderService>();

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();

    public virtual PriceBoard? Price { get; set; }
}
