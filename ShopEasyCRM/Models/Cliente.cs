using System;
using System.Collections.Generic;

namespace ShopEasyCRM.Models;

public partial class Cliente
{
    public int IdCliente { get; set; }

    public string? Nombre { get; set; }

    public string? Apellido { get; set; }

    public string? Correo { get; set; }

    public string? Telefono { get; set; }

    public string? Direccion { get; set; }

    public int? ProvinciaId { get; set; }

    public DateTime? FechaRegistro { get; set; }

    public string? Estado { get; set; }

    public virtual ICollection<ClienteEtiquetum> ClienteEtiqueta { get; set; } = new List<ClienteEtiquetum>();

    public virtual ICollection<Interaccione> Interacciones { get; set; } = new List<Interaccione>();

    public virtual ICollection<Notificacione> Notificaciones { get; set; } = new List<Notificacione>();

    public virtual ICollection<Pedido> Pedidos { get; set; } = new List<Pedido>();

    public virtual Provincia? Provincia { get; set; }

    public virtual ICollection<Ticket> Tickets { get; set; } = new List<Ticket>();
}
