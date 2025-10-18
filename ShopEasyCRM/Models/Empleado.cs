using System;
using System.Collections.Generic;

namespace ShopEasyCRM.Models;

public partial class Empleado
{
    public int IdEmpleado { get; set; }

    public string? Nombre { get; set; }

    public string? Email { get; set; }

    public string? Telefono { get; set; }

    public int? RolId { get; set; }

    public virtual ICollection<HistorialPedido> HistorialPedidos { get; set; } = new List<HistorialPedido>();

    public virtual ICollection<Interaccione> Interacciones { get; set; } = new List<Interaccione>();

    public virtual ICollection<LogsFacturacion> LogsFacturacions { get; set; } = new List<LogsFacturacion>();

    public virtual ICollection<ReportesActividad> ReportesActividads { get; set; } = new List<ReportesActividad>();

    public virtual Role? Rol { get; set; }

    public virtual ICollection<Ticket> Tickets { get; set; } = new List<Ticket>();
}
