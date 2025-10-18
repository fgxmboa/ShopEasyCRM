using System;
using System.Collections.Generic;

namespace ShopEasyCRM.Models;

public partial class ClienteEtiquetum
{
    public int IdRelacion { get; set; }

    public int? ClienteId { get; set; }

    public int? EtiquetaId { get; set; }

    public DateTime? FechaAsignacion { get; set; }

    public virtual Cliente? Cliente { get; set; }

    public virtual Etiqueta? Etiqueta { get; set; }
}
