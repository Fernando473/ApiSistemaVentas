using System;
using System.Collections.Generic;

namespace SistemaVentas.MODEL;

public partial class Producto
{
    public int IdProducto { get; set; }

    public string? Nombre { get; set; }

    public int? IdCategoria { get; set; }

    public int? Stock { get; set; }

    public decimal? Precio { get; set; }

    public ulong? EsActivo { get; set; }

    public DateTime FechaRegistro { get; set; }

    public virtual ICollection<DetalleVenta> Detalleventa { get; set; } = new List<DetalleVenta>();

    public virtual Categoria? IdCategoriaNavigation { get; set; }
}
