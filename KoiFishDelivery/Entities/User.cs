using System;
using System.Collections.Generic;

namespace KoiFishDelivery.Entities;

public partial class User
{
    public string UserId { get; set; } = null!;

    public string? FullName { get; set; }

    public string? Email { get; set; }

    public string? Password { get; set; }

    public int? Phone { get; set; }

    public string Role { get; set; } = null!;

    public DateOnly? DateOfBirth { get; set; }

    public string? Gender { get; set; }

    public virtual ICollection<Feedback> Feedbacks { get; set; } = new List<Feedback>();

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();

    public virtual ICollection<Shiper> Shipers { get; set; } = new List<Shiper>();
}
