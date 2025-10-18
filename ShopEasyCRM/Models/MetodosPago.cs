using System;
using System.Collections.Generic;

namespace ShopEasyCRM.Models;

public partial class MetodosPago
{
    public int IdMetodo { get; set; }

    public string? Nombre { get; set; }

    public string? Descripcion { get; set; }

    public virtual ICollection<Pedido> Pedidos { get; set; } = new List<Pedido>();
}
