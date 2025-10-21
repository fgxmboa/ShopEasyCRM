using System;
using System.Collections.Generic;

namespace ShopEasyCRM.Models;

public partial class ReportesActividad
{
    public int IdReporte { get; set; }

    public string? TipoReporte { get; set; }

    public DateTime? FechaGeneracion { get; set; }

    public string? GeneradoPor { get; set; }

    public string? Descripcion { get; set; }

    public virtual Persona? GeneradoPorNavigation { get; set; }
}
