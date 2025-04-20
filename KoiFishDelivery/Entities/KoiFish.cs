using System;
using System.Collections.Generic;

namespace KoiFishDelivery.Entities;

public partial class KoiFish
{
    public string KoiFishId { get; set; } = null!;

    public string? OrderId { get; set; }

    public string? Type { get; set; }

    public double? WeightAve { get; set; }

    public double? LenghtAve { get; set; }

    public string? Description { get; set; }

    public string? Manufacturer { get; set; }

    public int? Quantity { get; set; }
}
