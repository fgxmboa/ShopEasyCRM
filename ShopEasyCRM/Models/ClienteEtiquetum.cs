using System;
using System.Collections.Generic;

namespace ShopEasyCRM.Models;

public partial class ClienteEtiquetum
{
    public int IdClienteEtiqueta { get; set; }

    public string? ClienteId { get; set; }

    public int? EtiquetaId { get; set; }

    public DateTime? FechaAsignacion { get; set; }

    public virtual Persona? Cliente { get; set; }

    public virtual Etiqueta? Etiqueta { get; set; }
}
