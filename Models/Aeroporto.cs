using System;
using System.Collections.Generic;

namespace ExelFlightSheet.Models;

public partial class Aeroporto
{
    public string Citta { get; set; } = null!;

    public string Nazione { get; set; } = null!;

    public int? Numpiste { get; set; }

    public virtual ICollection<Volo> VoloCittaarrNavigations { get; set; } = new List<Volo>();

    public virtual ICollection<Volo> VoloCittapartNavigations { get; set; } = new List<Volo>();
}
