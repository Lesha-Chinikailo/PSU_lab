using System;
using System.Collections.Generic;

namespace Wpf_BD_6.Models;

public partial class AllInformationWorkerView
{
    public string Name { get; set; } = null!;

    public string Surname { get; set; } = null!;

    public string Email { get; set; } = null!;

    public double Rate { get; set; }

    public int IdSpeciality { get; set; }

    public int IdBrigade { get; set; }
}
