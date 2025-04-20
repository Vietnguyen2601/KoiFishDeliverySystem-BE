using System;
using System.Collections.Generic;

namespace KoiFishDelivery.Entities;

public partial class PaymentDetail
{
    public string PaymentId { get; set; } = null!;

    public string? OrderId { get; set; }

    public string? PaymentMethod { get; set; }

    public double? PaidAmount { get; set; }

    public DateTime? PaymentDate { get; set; }

    public virtual Order? Order { get; set; }
}
