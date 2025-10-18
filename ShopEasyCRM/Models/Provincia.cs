using System;
using System.Collections.Generic;

namespace ShopEasyCRM.Models;

public partial class Provincia
{
    public int IdProvincia { get; set; }

    public string? Nombre { get; set; }

    public virtual ICollection<Cliente> Clientes { get; set; } = new List<Cliente>();
}
