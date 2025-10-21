using System;
using System.Collections.Generic;

namespace ShopEasyCRM.Models;

public partial class Role
{
    public int IdRol { get; set; }

    public string? Nombre { get; set; }

    public string? Descripcion { get; set; }

    public virtual ICollection<Persona> Personas { get; set; } = new List<Persona>();
}
