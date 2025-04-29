using System;
using System.Collections.Generic;

namespace KoiFishDeliverySystem.Models;

public partial class PaymentDetail
{
    public string PaymentId { get; set; } = null!;

    public string? OrderId { get; set; }

    public string? PaymentMethod { get; set; }

    public decimal? PaidAmount { get; set; }

    public DateTime? PaymentDate { get; set; }

    public virtual Order? Order { get; set; }
}
