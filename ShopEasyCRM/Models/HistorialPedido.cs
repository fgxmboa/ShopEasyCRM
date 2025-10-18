using System;
using System.Collections.Generic;

namespace ShopEasyCRM.Models;

public partial class HistorialPedido
{
    public int IdHistorial { get; set; }

    public int? PedidoId { get; set; }

    public string? EstadoAnterior { get; set; }

    public string? EstadoNuevo { get; set; }

    public DateTime? FechaCambio { get; set; }

    public int? ActualizadoPor { get; set; }

    public virtual Empleado? ActualizadoPorNavigation { get; set; }

    public virtual Pedido? Pedido { get; set; }
}
