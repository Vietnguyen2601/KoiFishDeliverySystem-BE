using System;
using System.Collections.Generic;

namespace KoiFishDelivery.Entities;

public partial class Question
{
    public string QuestionId { get; set; } = null!;

    public int? QuestionNums { get; set; }

    public string? QuestionText { get; set; }

    public string? AnswerText { get; set; }
}
