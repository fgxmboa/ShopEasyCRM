using System;
using System.Collections.Generic;

namespace ShopEasyCRM.Models;

public partial class Persona
{
    public string NumeroCedula { get; set; } = null!;

    public string? Nombre { get; set; }

    public string? Apellido1 { get; set; }

    public string? Apellido2 { get; set; }

    public string? Email { get; set; }

    public string? Telefono { get; set; }

    public string? Direccion { get; set; }

    public int? ProvinciaId { get; set; }

    public DateOnly? FechaNacimiento { get; set; }

    public int? RolId { get; set; }

    public bool? Estado { get; set; }

    public virtual ICollection<ClienteEtiquetum> ClienteEtiqueta { get; set; } = new List<ClienteEtiquetum>();

    public virtual ICollection<HistorialPedido> HistorialPedidos { get; set; } = new List<HistorialPedido>();

    public virtual ICollection<Interaccione> InteraccioneClientes { get; set; } = new List<Interaccione>();

    public virtual ICollection<Interaccione> InteraccioneEmpleados { get; set; } = new List<Interaccione>();

    public virtual ICollection<LogsFacturacion> LogsFacturacions { get; set; } = new List<LogsFacturacion>();

    public virtual ICollection<Notificacione> Notificaciones { get; set; } = new List<Notificacione>();

    public virtual ICollection<Pedido> Pedidos { get; set; } = new List<Pedido>();

    public virtual Provincia? Provincia { get; set; }

    public virtual ICollection<ReportesActividad> ReportesActividads { get; set; } = new List<ReportesActividad>();

    public virtual Role? Rol { get; set; }

    public virtual ICollection<Ticket> TicketClientes { get; set; } = new List<Ticket>();

    public virtual ICollection<Ticket> TicketEmpleados { get; set; } = new List<Ticket>();
}
