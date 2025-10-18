using System;
using System.Collections.Generic;

namespace ShopEasyCRM.Models;

public partial class Etiqueta
{
    public int IdEtiqueta { get; set; }

    public string? Nombre { get; set; }

    public string? Descripcion { get; set; }

    public string? Criterio { get; set; }

    public virtual ICollection<ClienteEtiquetum> ClienteEtiqueta { get; set; } = new List<ClienteEtiquetum>();
}
