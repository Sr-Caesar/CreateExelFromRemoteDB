using System;
using System.Collections.Generic;

namespace ExelFlightSheet.Models;

public partial class Aereo
{
    public string Tipoaereo { get; set; } = null!;

    public int Numpasseggeri { get; set; }

    public int? Qntmerci { get; set; }

    public virtual ICollection<Volo> Volos { get; set; } = new List<Volo>();
}
