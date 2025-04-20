using System;
using System.Collections.Generic;

namespace KoiFishDelivery.Entities;

public partial class PriceBoard
{
    public string PriceId { get; set; } = null!;

    public string? Description { get; set; }

    public double? BasePrice { get; set; }

    public double? ExtraCost { get; set; }

    public virtual ICollection<Service> Services { get; set; } = new List<Service>();
}
