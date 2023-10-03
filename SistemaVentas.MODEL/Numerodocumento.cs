using System;
using System.Collections.Generic;

namespace SistemaVentas.MODEL;

public partial class Numerodocumento
{
    public int IdNumeroDocumento { get; set; }

    public int UltimoNumero { get; set; }

    public DateTime FechaRegistro { get; set; }
}
