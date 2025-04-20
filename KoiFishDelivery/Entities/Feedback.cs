using System;
using System.Collections.Generic;

namespace KoiFishDelivery.Entities;

public partial class Feedback
{
    public string FeedbackId { get; set; } = null!;

    public string? CustomerId { get; set; }

    public string? OrderId { get; set; }

    public int? Rating { get; set; }

    public string? Comment { get; set; }

    public virtual User? Customer { get; set; }

    public virtual Order? Order { get; set; }
}
