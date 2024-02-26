using System;
using System.Collections.Generic;

namespace Wpf_BD_6.Models;

public partial class Department
{
    public int IdDepartment { get; set; }

    public string NameDepartment { get; set; } = null!;

    public string DescriptionDepartment { get; set; } = null!;

    public int CountBrigade { get; set; }

    public virtual ICollection<Brigade> Brigades { get; set; } = new List<Brigade>();
}
