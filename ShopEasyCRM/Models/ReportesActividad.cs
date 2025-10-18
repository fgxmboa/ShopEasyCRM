using System;
using System.Collections.Generic;

namespace ShopEasyCRM.Models;

public partial class ReportesActividad
{
    public int IdReporte { get; set; }

    public string? TipoReporte { get; set; }

    public DateTime? FechaGeneracion { get; set; }

    public int? GeneradoPor { get; set; }

    public string? Ubicacion { get; set; }

    public string? Descripcion { get; set; }

    public virtual Empleado? GeneradoPorNavigation { get; set; }
}
