using System;
using System.Collections.Generic;

#nullable disable

namespace TexberAPI.Models
{
    public partial class CoLinea
    {
        public short CodigoEmpresa { get; set; } = 1;
        public string CoCodigoLinea { get; set; }
        public string Descripcion { get; set; }
    }
}
