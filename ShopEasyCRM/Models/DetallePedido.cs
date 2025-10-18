using System;
using System.Collections.Generic;

namespace ShopEasyCRM.Models;

public partial class DetallePedido
{
    public int IdDetalle { get; set; }

    public int? PedidoId { get; set; }

    public int? ProductoId { get; set; }

    public int? Cantidad { get; set; }

    public decimal? PrecioUnitario { get; set; }

    public decimal? Subtotal { get; set; }

    public virtual Pedido? Pedido { get; set; }

    public virtual Producto? Producto { get; set; }
}
