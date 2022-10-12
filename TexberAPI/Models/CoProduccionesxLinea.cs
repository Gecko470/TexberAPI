using System;
using System.Collections.Generic;

#nullable disable

namespace TexberAPI.Models
{
    public partial class CoProduccionesxLinea
    {
        public short CodigoEmpresa { get; set; } = 1;
        public string CoCodigoLinea { get; set; }
        public int NumeroFabricacion { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime? FechaFinal { get; set; }
        public short StatusActivo { get; set; }
    }
}
