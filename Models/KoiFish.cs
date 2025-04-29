using System;
using System.Collections.Generic;

namespace KoiFishDeliverySystem.Models;

public partial class KoiFish
{
    public string KoiFishId { get; set; } = null!;

    public string? OrderId { get; set; }

    public string? Type { get; set; }

    public decimal? WeightAve { get; set; }

    public decimal? LenghtAve { get; set; }

    public string? Description { get; set; }

    public string? Manufacturer { get; set; }

    public int? Quantity { get; set; }

    public virtual Order? Order { get; set; }
}
