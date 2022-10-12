using System;
using System.Collections.Generic;

#nullable disable

namespace TexberAPI.Models
{
    public partial class AcumuladoStock
    {
        public short CodigoEmpresa { get; set; } = 1;
        public short Ejercicio { get; set; } = (short)DateTime.Now.Year;
        public string CodigoArticulo { get; set; }
        public string CodigoAlmacen { get; set; }
        public short Periodo { get; set; }
        public string Partida { get; set; }
        public string TipoUnidadMedida { get; set; }
        public string CodigoColor { get; set; }
        public string CodigoTalla01 { get; set; }
        public decimal UnidadEntrada { get; set; }
        public decimal UnidadSalida { get; set; }
        public decimal UnidadSaldo { get; set; }
        public decimal UnidadCompra { get; set; }
        public decimal UnidadConsumo { get; set; }
        public decimal UnidadEntradaTipo { get; set; }
        public decimal UnidadSalidaTipo { get; set; }
        public decimal UnidadSaldoTipo { get; set; }
        public decimal UnidadCompraTipo { get; set; }
        public decimal UnidadConsumoTipo { get; set; }
        public decimal ImporteEntrada { get; set; }
        public decimal CosteSalida { get; set; }
        public decimal ImporteSaldo { get; set; }
        public decimal ImporteSalida { get; set; }
        public decimal ImporteCompra { get; set; }
        public decimal ImporteConsumo { get; set; }
        public decimal PrecioMedio { get; set; }
        public decimal PrecioUltimaEntrada { get; set; }
        public decimal PrecioUltimaSalida { get; set; }
        public DateTime? FechaUltimaEntrada { get; set; }
        public DateTime? FechaUltimaSalida { get; set; }
        public DateTime? FechaCaducidad { get; set; }
        public string Ubicacion { get; set; }
        public short StatusRecalculo { get; set; }
        public Guid IdAcumuladoStock { get; set; }
    }
}
