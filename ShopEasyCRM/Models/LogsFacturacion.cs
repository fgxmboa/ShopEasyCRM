using System;
using System.Collections.Generic;

namespace ShopEasyCRM.Models;

public partial class LogsFacturacion
{
    public int IdLog { get; set; }

    public int? FacturaId { get; set; }

    public DateTime? Fecha { get; set; }

    public string? Detalle { get; set; }

    public int? GeneradoPor { get; set; }

    public virtual Factura? Factura { get; set; }

    public virtual Empleado? GeneradoPorNavigation { get; set; }
}
