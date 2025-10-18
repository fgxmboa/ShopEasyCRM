using System;
using System.Collections.Generic;

namespace ShopEasyCRM.Models;

public partial class Factura
{
    public int IdFactura { get; set; }

    public int? PedidoId { get; set; }

    public string? NumeroFactura { get; set; }

    public string? ClaveHacienda { get; set; }

    public DateTime? FechaEmision { get; set; }

    public string? EstadoEnvio { get; set; }

    public decimal? Total { get; set; }

    public virtual ICollection<LogsFacturacion> LogsFacturacions { get; set; } = new List<LogsFacturacion>();

    public virtual Pedido? Pedido { get; set; }
}
