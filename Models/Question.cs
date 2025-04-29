using System;
using System.Collections.Generic;

namespace KoiFishDeliverySystem.Models;

public partial class Question
{
    public string QuestionId { get; set; } = null!;

    public string? UserId { get; set; }

    public string? QuestionText { get; set; }

    public string? AnswerText { get; set; }

    public virtual User? User { get; set; }
}
