using System;
using System.Collections.Generic;

namespace management_cursesDL.EF.Models;

public partial class Student
{
    public string Name { get; set; } = null!;

    public int IdNumber { get; set; }

    public string? Phone { get; set; }

    public string? Address { get; set; }

    public DateOnly? RegistrationDate { get; set; }

    public string Grade { get; set; } = null!;

    public int? CourseCode { get; set; }

    public virtual Course? CourseCodeNavigation { get; set; }
}
