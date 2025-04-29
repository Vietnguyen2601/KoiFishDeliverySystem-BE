using System;
using System.Collections.Generic;

namespace KoiFishDeliverySystem.Models;

public partial class Order
{
    public string OrderId { get; set; } = null!;

    public string? UserId { get; set; }

    public string? ShiperId { get; set; }

    public DateTime? OrderDate { get; set; }

    public string? PickupAddress { get; set; }

    public string? DeliveryAddress { get; set; }

    public string? DeliveryStatus { get; set; }

    public decimal? TotalPrice { get; set; }

    public string? PaymentStatus { get; set; }

    public string? Notes { get; set; }

    public virtual ICollection<Feedback> Feedbacks { get; set; } = new List<Feedback>();

    public virtual ICollection<KoiFish> KoiFishes { get; set; } = new List<KoiFish>();

    public virtual ICollection<OrderService> OrderServices { get; set; } = new List<OrderService>();

    public virtual ICollection<PaymentDetail> PaymentDetails { get; set; } = new List<PaymentDetail>();

    public virtual Shiper? Shiper { get; set; }

    public virtual User? User { get; set; }
}
