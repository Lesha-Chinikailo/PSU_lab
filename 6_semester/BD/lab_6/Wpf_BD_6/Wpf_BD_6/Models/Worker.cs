using System;
using System.Collections.Generic;

namespace Wpf_BD_6.Models;

public partial class Worker
{
    public int IdWorker { get; set; }

    public string Name { get; set; } = null!;

    public string Surname { get; set; } = null!;

    public string Email { get; set; } = null!;

    public double Rate { get; set; }

    public int IdSpeciality { get; set; }

    public int IdBrigade { get; set; }

    public virtual Brigade IdBrigadeNavigation { get; set; } = null!;

    public virtual Speciality IdSpecialityNavigation { get; set; } = null!;
}
