using System;

namespace TexberAPI.DTOs
{
    public class ArticuloDTO
    {
        public string CodigoArticulo { get; set; }
        public string DescripcionArticulo { get; set; }
        public string CodigoAlternativo { get; set; }
        public string TipoArticulo { get; set; }
        public string CodigoFamilia { get; set; }
        public decimal PrecioVenta { get; set; }
    }
}
