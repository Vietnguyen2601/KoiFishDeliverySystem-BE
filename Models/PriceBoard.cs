using System;
using System.Collections.Generic;

namespace KoiFishDeliverySystem.Models;

public partial class PriceBoard
{
    public string PriceId { get; set; } = null!;

    public string? Description { get; set; }

    public decimal? BasePrice { get; set; }

    public decimal? ExtraCost { get; set; }

    public virtual ICollection<Service> Services { get; set; } = new List<Service>();
}
