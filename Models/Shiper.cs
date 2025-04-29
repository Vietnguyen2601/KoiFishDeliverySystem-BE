using System;
using System.Collections.Generic;

namespace KoiFishDeliverySystem.Models;

public partial class Shiper
{
    public string ShiperId { get; set; } = null!;

    public string? UserId { get; set; }

    public string? Available { get; set; }

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();

    public virtual User? User { get; set; }
}
