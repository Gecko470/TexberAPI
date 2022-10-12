using System;
using System.Collections.Generic;

#nullable disable

namespace TexberAPI.Models
{
    public partial class MovimientoStock
    {
        public short CodigoEmpresa { get; set; } = 1;
        public short Ejercicio { get; set; } = (short)DateTime.Now.Year;
        public short Periodo { get; set; } = (short)DateTime.Now.Month;
        public DateTime Fecha { get; set; } = DateTime.Now;
        public DateTime FechaRegistro { get; set; } = DateTime.Now;
        public string Serie { get; set; }
        public int Documento { get; set; }
        public string CodigoArticulo { get; set; }
        public string CodigoAlmacen { get; set; }
        public string AlmacenContrapartida { get; set; }
        public string Partida { get; set; }
        public string Partida2 { get; set; }
        public string CodigoColor { get; set; }
        public short GrupoTalla { get; set; }
        public string CodigoTalla01 { get; set; }
        public byte TipoMovimiento { get; set; }
        public decimal Unidades { get; set; }
        public string UnidadMedida1 { get; set; }
        public decimal Precio { get; set; }
        public decimal Importe { get; set; }
        public decimal Unidades2 { get; set; }
        public string UnidadMedida2 { get; set; }
        public decimal FactorConversion { get; set; }
        public string Comentario { get; set; }
        public string CodigoCanal { get; set; }
        public string CodigoCliente { get; set; }
        public string CodigoProveedor { get; set; }
        public DateTime? FechaCaduca { get; set; }
        public string Ubicacion { get; set; }
        public short StatusAcumulado { get; set; } = -1;
        public string OrigenMovimiento { get; set; } = "T";
        public Guid MovPosicion { get; set; }
        public Guid MovTraspaso { get; set; }
        public short UsuarioProceso { get; set; }
        public short EmpresaOrigen { get; set; } = 1;
        public Guid MovOrigen { get; set; }
        public short EjercicioDocumento { get; set; } = (short)DateTime.Now.Year;
        public Guid MovConsumo { get; set; }
        public Guid MovIdentificador { get; set; }
        public decimal ImporteCoste { get; set; }
        public decimal UnidadEntrada { get; set; }
        public decimal UnidadStock { get; set; }
        public decimal PrecioMedio { get; set; }
        public short CalculoPrecioMedio { get; set; }
        public Guid Proceso { get; set; }
        public short SysTraspasoLwg { get; set; }
        public string NumeroSerieLc { get; set; }
        public short CoBobinas { get; set; }
        public short NumeroDomicilio { get; set; }
        public string CoCodigoLinea { get; set; }
    }
}
