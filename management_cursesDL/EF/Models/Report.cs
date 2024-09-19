using System;
using System.Collections.Generic;

namespace management_cursesDL.EF.Models;

public partial class Report
{
    public int RepId { get; set; }

    public DateOnly? ReportDate { get; set; }

    public int? TeacherId { get; set; }

    public int? DirectorId { get; set; }

    public TimeOnly? FormTime { get; set; }

    public TimeOnly? ToTime { get; set; }

    public decimal? NumHours { get; set; }

    public decimal? Travel { get; set; }

    public virtual User? Director { get; set; }

    public virtual User? Teacher { get; set; }
}
