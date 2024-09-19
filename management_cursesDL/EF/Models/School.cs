using System;
using System.Collections.Generic;

namespace management_cursesDL.EF.Models;

public partial class School
{
    public int SchooleCode { get; set; }

    public string SchooleName { get; set; } = null!;

    public int? DirectorId { get; set; }

    public string? Adress { get; set; }

    public virtual ICollection<Course> Courses { get; set; } = new List<Course>();

    public virtual User? Director { get; set; }
}
