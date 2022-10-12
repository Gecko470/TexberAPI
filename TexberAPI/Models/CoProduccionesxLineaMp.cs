using System;
using System.Collections.Generic;

#nullable disable

namespace TexberAPI.Models
{
    public partial class CoProduccionesxLineaMp
    {
        public short CodigoEmpresa { get; set; } = 1;
        public int NumeroFabricacion { get; set; }
        public string CoCodigoLinea { get; set; }
        public string CodigoArticulo { get; set; }
        public string Partida { get; set; }
        public decimal Unidades { get; set; }
    }
}
