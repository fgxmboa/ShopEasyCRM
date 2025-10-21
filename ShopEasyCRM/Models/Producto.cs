using System;
using System.Collections.Generic;

namespace ShopEasyCRM.Models;

public partial class Producto
{
    public int IdProducto { get; set; }

    public string? CodigoBarras { get; set; }

    public string? Nombre { get; set; }

    public string? Descripcion { get; set; }

    public decimal? Precio { get; set; }

    public string? Categoria { get; set; }

    public int? Stock { get; set; }

    public string? Estado { get; set; }

    public virtual ICollection<DetallePedido> DetallePedidos { get; set; } = new List<DetallePedido>();

    public virtual ICollection<Inventario> Inventarios { get; set; } = new List<Inventario>();
}
