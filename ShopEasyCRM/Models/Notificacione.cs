using System;
using System.Collections.Generic;

namespace ShopEasyCRM.Models;

public partial class Notificacione
{
    public int IdNotificacion { get; set; }

    public int? ClienteId { get; set; }

    public string? Mensaje { get; set; }

    public string? Tipo { get; set; }

    public DateTime? FechaEnvio { get; set; }

    public bool? Leido { get; set; }

    public virtual Cliente? Cliente { get; set; }
}
