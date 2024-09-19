using System;
using System.Collections.Generic;

namespace management_cursesDL.EF.Models;

public partial class Course
{
    public int CourseCode { get; set; }

    public string CourseName { get; set; } = null!;

    public decimal Amount { get; set; }

    public int? TeacherId { get; set; }

    public int? DirectorId { get; set; }

    public int? SchooleCode { get; set; }

    public int? CourseDuration { get; set; }

    public virtual User? Director { get; set; }

    public virtual School? SchooleCodeNavigation { get; set; }

    public virtual ICollection<Student> Students { get; set; } = new List<Student>();

    public virtual User? Teacher { get; set; }
}
