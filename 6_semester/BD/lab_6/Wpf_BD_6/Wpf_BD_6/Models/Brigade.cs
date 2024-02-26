using System;
using System.Collections.Generic;

namespace Wpf_BD_6.Models;

public partial class Brigade
{
    public int IdBrigade { get; set; }

    public int CountWorker { get; set; }

    public string TypeBrigade { get; set; } = null!;

    public int IdDepartment { get; set; }

    public virtual Department IdDepartmentNavigation { get; set; } = null!;

    public virtual ICollection<Worker> Workers { get; set; } = new List<Worker>();
}
