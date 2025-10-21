using System;
using System.Collections.Generic;

namespace ShopEasyCRM.Models;

public partial class Interaccione
{
    public int IdInteraccion { get; set; }

    public string? ClienteId { get; set; }

    public int? CanalId { get; set; }

    public DateTime? Fecha { get; set; }

    public string? Asunto { get; set; }

    public string? Descripcion { get; set; }

    public string? EmpleadoId { get; set; }

    public virtual CanalesComunicacion? Canal { get; set; }

    public virtual Persona? Cliente { get; set; }

    public virtual Persona? Empleado { get; set; }
}
