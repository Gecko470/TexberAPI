using System;

namespace TexberAPI.DTOs
{
    public class AcumuladoStockDTO
    {
        public string CodigoArticulo { get; set; }
        public string CodigoAlmacen { get; set; }
        public string Partida { get; set; }
        public short Periodo { get; set; }
        public decimal UnidadEntrada { get; set; }
        public decimal UnidadSalida { get; set; }
        public decimal UnidadSaldo { get; set; }
        public DateTime? FechaUltimaEntrada { get; set; }
        public DateTime? FechaUltimaSalida { get; set; }
    }
}
