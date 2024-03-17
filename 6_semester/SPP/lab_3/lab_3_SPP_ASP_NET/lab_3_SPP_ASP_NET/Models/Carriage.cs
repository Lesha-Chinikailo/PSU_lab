using System;
using System.Collections.Generic;

namespace lab_3_SPP_ASP_NET.Models;

public partial class Carriage
{
    public int CarriageId { get; set; }

    public int NumberOfSeats { get; set; }

    public int TrainId { get; set; }

    public virtual Train Train { get; set; } = null!;
}
