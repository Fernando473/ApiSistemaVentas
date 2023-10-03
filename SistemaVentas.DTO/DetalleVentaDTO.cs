using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaVentas.DTO
{
    internal class DetalleVentaDTO
    {
        public int? IdProducto { get; set; }

        public int? Cantidad { get; set; }

        public decimal? Precio { get; set; }

        public string? Total { get; set; }

        public string DescripcionProducto { get; set; }
        

    }
}
