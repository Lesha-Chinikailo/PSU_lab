using System;
using System.Collections.Generic;

namespace lab_3_SPP_ASP_NET.Models;

public partial class Train
{
    public int TrainId { get; set; }

    public string? TrainName { get; set; }

    public virtual ICollection<Carriage> Carriages { get; set; } = new List<Carriage>();
}
