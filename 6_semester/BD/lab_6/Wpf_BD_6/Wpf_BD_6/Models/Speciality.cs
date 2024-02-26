using System;
using System.Collections.Generic;

namespace Wpf_BD_6.Models;

public partial class Speciality
{
    public int IdSpeciality { get; set; }

    public decimal SalaryOneRate { get; set; }

    public string NameSpeciality { get; set; } = null!;

    public string Description { get; set; } = null!;

    public virtual ICollection<Worker> Workers { get; set; } = new List<Worker>();
}
