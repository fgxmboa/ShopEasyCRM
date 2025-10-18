using System;
using System.Collections.Generic;

namespace ShopEasyCRM.Models;

public partial class CanalesComunicacion
{
    public int IdCanal { get; set; }

    public string? Nombre { get; set; }

    public string? Descripcion { get; set; }

    public virtual ICollection<Interaccione> Interacciones { get; set; } = new List<Interaccione>();

    public virtual ICollection<Ticket> Tickets { get; set; } = new List<Ticket>();
}
