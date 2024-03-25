using System;
using System.Collections.Generic;

namespace WorkingDiary;

public partial class WorkerTask
{
    public long TaskId { get; set; }

    public string TaskName { get; set; } = null!;

    public string? TaskDescription { get; set; }

    public string? TaskOwnerName { get; set; }

    public string? TaskOwnerSurname { get; set; }

    public DateOnly? TaskCreateDate { get; set; }

    public DateOnly? TaskEndDate { get; set; }

    public string? TaskStatus { get; set; }
}
