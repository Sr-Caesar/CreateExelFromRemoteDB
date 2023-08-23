using System;
using System.Collections.Generic;

namespace ExelFlightSheet.Models;

public partial class Volo
{
    public int Id { get; set; }

    public string Idvolo { get; set; } = null!;

    public DateTime Giornosett { get; set; }

    public string Cittapart { get; set; } = null!;

    public DateTime Orapart { get; set; }

    public string Cittaarr { get; set; } = null!;

    public DateTime Oraarr { get; set; }

    public string Tipoaereo { get; set; } = null!;

    public virtual Aeroporto CittaarrNavigation { get; set; } = null!;

    public virtual Aeroporto CittapartNavigation { get; set; } = null!;

    public virtual Aereo TipoaereoNavigation { get; set; } = null!;
}
