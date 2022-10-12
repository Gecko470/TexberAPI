using System;
using System.Collections.Generic;

#nullable disable

namespace TexberAPI.Models
{
    public partial class LineasAlbaranProveedor
    {
        public short CodigoEmpresa { get; set; } = 1;
        public short EjercicioAlbaran { get; set; } = (short)DateTime.Now.Year;
        public string SerieAlbaran { get; set; }
        public int NumeroAlbaran { get; set; }
        public short Orden { get; set; }
        public Guid LineasPosicion { get; set; }
        public Guid LineaPedido { get; set; }
        public Guid IdIncidencia { get; set; }
        public DateTime FechaRegistro { get; set; }
        public DateTime FechaAlbaran { get; set; }
        public string CodigoArticulo { get; set; }
        public string CodigoAlmacen { get; set; }
        public string Partida { get; set; }
        public string DescripcionArticulo { get; set; }
        public string Descripcion2Articulo { get; set; }
        public string DescripcionLinea { get; set; }
        public string CodigoFamilia { get; set; }
        public string CodigoSubfamilia { get; set; }
        public string UnidadMedida1 { get; set; }
        public string UnidadMedida2 { get; set; }
        public decimal FactorConversion { get; set; }
        public string CodigodelProveedor { get; set; }
        public string CodigoDefinicion { get; set; }
        public byte CodigoTransaccion { get; set; }
        public string CodigoProyecto { get; set; }
        public string CodigoSeccion { get; set; }
        public string CodigoDepartamento { get; set; }
        public string CodigoColor { get; set; }
        public short GrupoTalla { get; set; }
        public string CodigoTalla01 { get; set; }
        public short LineaFabricacion { get; set; }
        public short BloqueoRebaje { get; set; }
        public short AcumulaEstadistica { get; set; }
        public short StatusStock { get; set; }
        public short StatusEstadis { get; set; }
        public DateTime? FechaCaduca { get; set; }
        public string Ubicacion { get; set; }
        public byte GrupoIva { get; set; }
        public short CodigoIva { get; set; }
        public short IvaIncluido { get; set; }
        public decimal Descuento { get; set; }
        public decimal Descuento2 { get; set; }
        public decimal Descuento3 { get; set; }
        public decimal Iva { get; set; }
        public decimal Recargo { get; set; }
        public decimal BaseCorreccion { get; set; }
        public short EjercicioPedido { get; set; }
        public string SeriePedido { get; set; }
        public int NumeroPedido { get; set; }
        public short EjercicioFactura { get; set; }
        public string SerieFactura { get; set; }
        public int NumeroFactura { get; set; }
        public int CodigoAgrupacion { get; set; }
        public int NumeroAgrupaciones { get; set; }
        public decimal UnidadesAgrupacion { get; set; }
        public decimal UnidadesRecibidas { get; set; }
        public decimal Unidades { get; set; }
        public decimal Unidades2 { get; set; }
        public decimal Precio { get; set; }
        public decimal PrecioRebaje { get; set; }
        public decimal IncrementoCoste { get; set; }
        public decimal ImporteBruto { get; set; }
        public decimal ImporteBrutoDivisa { get; set; }
        public decimal ImporteDescuento { get; set; }
        public decimal ImporteDescuentoDivisa { get; set; }
        public decimal ImporteNeto { get; set; }
        public decimal ImporteNetoDivisa { get; set; }
        public decimal ImporteDescuentoProveedor { get; set; }
        public decimal ImporteDtoProveedorDivisa { get; set; }
        public decimal ImporteParcial { get; set; }
        public decimal ImporteParcialDivisa { get; set; }
        public decimal ImporteProntoPago { get; set; }
        public decimal ImporteProntoPagoDivisa { get; set; }
        public decimal BaseImponible { get; set; }
        public decimal BaseImponibleDivisa { get; set; }
        public decimal BaseIva { get; set; }
        public decimal BaseIvaDivisa { get; set; }
        public decimal CuotaIva { get; set; }
        public decimal CuotaIvaDivisa { get; set; }
        public decimal CuotaRecargo { get; set; }
        public decimal CuotaRecargoDivisa { get; set; }
        public decimal TotalIva { get; set; }
        public decimal TotalIvaDivisa { get; set; }
        public decimal ImporteLiquido { get; set; }
        public decimal ImporteLiquidoDivisa { get; set; }
        public decimal ImporteRappel { get; set; }
        public decimal ImporteRappelDivisa { get; set; }
        public string TipoArticulo { get; set; }
        public string NumeroSerieLc { get; set; }
        public int FactorPrecioCompra { get; set; }
        public byte TipoUnidadCalculo { get; set; }
        public decimal Largo { get; set; }
        public decimal Alto { get; set; }
        public decimal Ancho { get; set; }
        public decimal Dimension { get; set; }
        public string AnaCapitulo { get; set; }
        public string AnaLote { get; set; }
        public short EjercicioExpediente { get; set; }
        public string SerieExpediente { get; set; }
        public int NumeroExpediente { get; set; }
        public short AcumulaCosteProyectos { get; set; }
        public int Bultos { get; set; }
        public short GeneraInmovilizado { get; set; }
        public string CodigoElemento { get; set; }
        public short CoBobinas { get; set; }
    }
}
