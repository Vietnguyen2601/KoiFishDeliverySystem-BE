using System;
using System.Collections.Generic;

namespace KoiFishDeliverySystem.Models;

public partial class Feedback
{
    public string FeedbackId { get; set; } = null!;

    public string? OrderId { get; set; }

    public int? Rating { get; set; }

    public string? Comment { get; set; }

    public virtual Order? Order { get; set; }
}
