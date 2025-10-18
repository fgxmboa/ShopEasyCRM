using System;
using System.Collections.Generic;

namespace ShopEasyCRM.Models;

public partial class Ticket
{
    public int IdTicket { get; set; }

    public int? ClienteId { get; set; }

    public int? EmpleadoId { get; set; }

    public int? CanalId { get; set; }

    public string? Categoria { get; set; }

    public string? Estado { get; set; }

    public string? Prioridad { get; set; }

    public DateTime? FechaCreacion { get; set; }

    public DateTime? FechaCierre { get; set; }

    public string? Descripcion { get; set; }

    public virtual CanalesComunicacion? Canal { get; set; }

    public virtual Cliente? Cliente { get; set; }

    public virtual Empleado? Empleado { get; set; }
}
