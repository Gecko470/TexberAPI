using System;
using System.Collections.Generic;

#nullable disable

namespace TexberAPI.Models
{
    public partial class CoProduccionesxLineaPf
    {
        public short CodigoEmpresa { get; set; } = 1;
        public string CoCodigoLinea { get; set; }
        public int NumeroFabricacion { get; set; }
        public string CodigoArticulo { get; set; }
        public string Partida { get; set; }
        public string CodigoProveedor { get; set; }
        public string CoFibra { get; set; }
        public short EjercicioPedido { get; set; }
        public string SeriePedido { get; set; }
        public int NumeroPedido { get; set; }
    }
}
