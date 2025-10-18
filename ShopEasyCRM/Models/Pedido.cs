using System;
using System.Collections.Generic;

namespace ShopEasyCRM.Models;

public partial class Pedido
{
    public int IdPedido { get; set; }

    public int? ClienteId { get; set; }

    public int? MetodoPagoId { get; set; }

    public DateTime? FechaPedido { get; set; }

    public string? Estado { get; set; }

    public decimal? Total { get; set; }

    public virtual Cliente? Cliente { get; set; }

    public virtual ICollection<DetallePedido> DetallePedidos { get; set; } = new List<DetallePedido>();

    public virtual ICollection<Factura> Facturas { get; set; } = new List<Factura>();

    public virtual ICollection<HistorialPedido> HistorialPedidos { get; set; } = new List<HistorialPedido>();

    public virtual MetodosPago? MetodoPago { get; set; }
}
