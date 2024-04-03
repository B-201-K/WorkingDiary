using System;
using System.Collections.Generic;

namespace WorkingDiary;

public partial class WorkerTask
{
    public int TaskId { get; set; }

    public string TaskName { get; set; } = null!;

    public string? TaskDescription { get; set; }

    public string? TaskOwnerName { get; set; }

    public string? TaskOwnerSurname { get; set; }

    public DateTime? TaskCreateDate { get; set; }

    public DateTime? TaskEndDate { get; set; }

    public string? TaskStatus { get; set; }
}
