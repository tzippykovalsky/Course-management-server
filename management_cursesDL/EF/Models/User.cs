using System;
using System.Collections.Generic;

namespace management_cursesDL.EF.Models;

public partial class User
{
    public int UserId { get; set; }

    public string Name { get; set; } = null!;

    public string Password { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string? Phone { get; set; }

    public decimal? PayLesson { get; set; }

    public int? Role { get; set; }

    public string? Adress { get; set; }

    public virtual ICollection<Course> CourseDirectors { get; set; } = new List<Course>();

    public virtual ICollection<Course> CourseTeachers { get; set; } = new List<Course>();

    public virtual ICollection<Report> ReportDirectors { get; set; } = new List<Report>();

    public virtual ICollection<Report> ReportTeachers { get; set; } = new List<Report>();

    public virtual ICollection<School> Schools { get; set; } = new List<School>();
}
