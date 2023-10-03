using System;
using System.Collections.Generic;

namespace SistemaVentas.MODEL;

public partial class Categoria
{
    public int IdCategoria { get; set; }

    public string? Nombre { get; set; }

    public ulong? EsActivo { get; set; }

    public DateTime FechaRegistro { get; set; }

    public virtual ICollection<Producto> Productos { get; set; } = new List<Producto>();
}
