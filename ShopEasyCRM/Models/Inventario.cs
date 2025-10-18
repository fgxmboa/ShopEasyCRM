using System;
using System.Collections.Generic;

namespace ShopEasyCRM.Models;

public partial class Inventario
{
    public int IdInventario { get; set; }

    public int? ProductoId { get; set; }

    public int? CantidadActual { get; set; }

    public int? PuntoReorden { get; set; }

    public string? Ubicacion { get; set; }

    public DateTime? FechaActualizacion { get; set; }

    public virtual Producto? Producto { get; set; }
}
