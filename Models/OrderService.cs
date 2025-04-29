using System;
using System.Collections.Generic;

namespace KoiFishDeliverySystem.Models;

public partial class OrderService
{
    public string OrderServiceId { get; set; } = null!;

    public string? OrderId { get; set; }

    public string? ServiceId { get; set; }

    public virtual Order? Order { get; set; }

    public virtual Service? Service { get; set; }
}
