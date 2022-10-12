using System;
using System.Collections.Generic;

#nullable disable

namespace TexberAPI.Models
{
    public partial class CabeceraAlbaranProveedor
    {
        public short CodigoEmpresa { get; set; } = 1;
        public string IdDelegacion { get; set; }
        public short EjercicioAlbaran { get; set; } = (short)DateTime.Now.Year;
        public string SerieAlbaran { get; set; }
        public int NumeroAlbaran { get; set; }
        public DateTime FechaAlbaran { get; set; } = DateTime.Now;
        public string CodigoProveedor { get; set; }
        public short NumeroLineas { get; set; }
        public string SiglaNacion { get; set; }
        public string CifDni { get; set; }
        public string CifEuropeo { get; set; }
        public string RazonSocial { get; set; }
        public string RazonSocial2 { get; set; }
        public string Nombre { get; set; }
        public string Domicilio { get; set; }
        public string Domicilio2 { get; set; }
        public string CodigoPostal { get; set; }
        public string CodigoMunicipio { get; set; }
        public string Municipio { get; set; }
        public string ColaMunicipio { get; set; }
        public string CodigoProvincia { get; set; }
        public string Provincia { get; set; }
        public short CodigoNacion { get; set; }
        public string Nacion { get; set; }
        public short CodigoCondiciones { get; set; }
        public string FormadePago { get; set; }
        public byte NumeroPlazos { get; set; }
        public short DiasPrimerPlazo { get; set; }
        public short DiasEntrePlazos { get; set; }
        public byte DiasFijos1 { get; set; }
        public byte DiasFijos2 { get; set; }
        public byte DiasFijos3 { get; set; }
        public short InicioNoPago { get; set; }
        public short FinNoPago { get; set; }
        public short ControlarFestivos { get; set; }
        public byte DiasRetroceso { get; set; }
        public short MesesComerciales { get; set; }
        public string CodigoContable { get; set; }
        public string CodigoDefinicion { get; set; }
        public string RemesaHabitual { get; set; }
        public string CodigoBanco { get; set; }
        public string CodigoAgencia { get; set; }
        public string Dc { get; set; }
        public string Ccc { get; set; }
        public string Iban { get; set; }
        public byte CodigoTransaccion { get; set; }
        public short CodigoTipoEfecto { get; set; }
        public short DomicilioRecibo { get; set; }
        public short Bloqueo { get; set; }
        public short StatusFacturado { get; set; }
        public short StatusListadoAlbaran { get; set; }
        public short StatusEstadis { get; set; }
        public short StatusAbono { get; set; }
        public short StatusContabilizado { get; set; }
        public short StatusAnalitica { get; set; }
        public short AgruparAlbaranes { get; set; }
        public string MascaraAlbaran { get; set; }
        public string MascaraFactura { get; set; }
        public short FinanciacionSobreBase { get; set; }
        public short TarifaPrecio { get; set; }
        public short TarifaDescuento { get; set; }
        public string IndicadorIva { get; set; }
        public byte GrupoIva { get; set; }
        public decimal Descuento { get; set; }
        public decimal ProntoPago { get; set; }
        public decimal Retencion { get; set; }
        public decimal Financiacion { get; set; }
        public decimal Rappel { get; set; }
        public string CodigoProyecto { get; set; }
        public string CodigoSeccion { get; set; }
        public string CodigoDepartamento { get; set; }
        public string CodigoCanal { get; set; }
        public int CodigoZona { get; set; }
        public int CodigoTransportista { get; set; }
        public string TipoPortes { get; set; }
        public string ObservacionesProveedor { get; set; }
        public string ObservacionesAlbaran { get; set; }
        public string ObservacionesFactura { get; set; }
        public string SuAlbaranNo { get; set; }
        public DateTime? FechaSuAlbaran { get; set; } = DateTime.Now;
        public short EjercicioPedido { get; set; }
        public string SeriePedido { get; set; }
        public int NumeroPedido { get; set; }
        public DateTime? FechaFactura { get; set; }
        public short EjercicioFactura { get; set; }
        public string SerieFactura { get; set; }
        public int NumeroFactura { get; set; }
        public short EnEuros { get; set; }
        public string CodigoDivisa { get; set; }
        public string CodigoIdioma { get; set; }
        public short MantenerCambio { get; set; }
        public decimal FactorCambio { get; set; }
        public decimal ImporteCambio { get; set; }
        public decimal ImporteCambioViejo { get; set; }
        public decimal ImportePortes { get; set; }
        public decimal ImportePortesDivisa { get; set; }
        public decimal ImporteBruto { get; set; }
        public decimal ImporteBrutoDivisa { get; set; }
        public decimal ImporteDescuentoLineas { get; set; }
        public decimal ImporteDtoLineasDivisa { get; set; }
        public decimal ImporteNetoLineas { get; set; }
        public decimal ImporteNetoLineasDivisa { get; set; }
        public decimal ImporteDescuento { get; set; }
        public decimal ImporteDescuentoDivisa { get; set; }
        public decimal ImporteParcial { get; set; }
        public decimal ImporteParcialDivisa { get; set; }
        public decimal ImporteProntoPago { get; set; }
        public decimal ImporteProntoPagoDivisa { get; set; }
        public decimal BaseImponible { get; set; }
        public decimal BaseImponibleDivisa { get; set; }
        public decimal TotalCuotaIva { get; set; }
        public decimal TotalCuotaIvaDivisa { get; set; }
        public decimal TotalCuotaRecargo { get; set; }
        public decimal TotalCuotaRecargoDivisa { get; set; }
        public decimal TotalIva { get; set; }
        public decimal TotalIvaDivisa { get; set; }
        public decimal ImporteFinanciacion { get; set; }
        public decimal ImporteFinanciacionDivisa { get; set; }
        public decimal ImporteLiquido { get; set; }
        public decimal ImporteLiquidoDivisa { get; set; }
        public decimal ImporteRappel { get; set; }
        public decimal ImporteRappelDivisa { get; set; }
        public decimal ImporteRetencion { get; set; }
        public decimal ImporteRetencionDivisa { get; set; }
        public decimal ImporteFactura { get; set; }
        public decimal ImporteFacturaDivisa { get; set; }
        public byte PeriodicidadFacturas { get; set; }
        public short EjercicioFacturaOriginal { get; set; }
        public string SerieFacturaOriginal { get; set; }
        public int NumeroFacturaOriginal { get; set; }
        public DateTime? FechaSuFactura { get; set; }
        public string SuFacturaNo { get; set; }
        public string ReferenciaEdi { get; set; }
        public short CodigoTerritorio { get; set; }
        public string AnaLote { get; set; }
        public string AnaCapitulo { get; set; }
        public short RetencionConIva { get; set; }
        public short EjercicioExpediente { get; set; }
        public string SerieExpediente { get; set; }
        public int NumeroExpediente { get; set; }
        public string CodigoContableAnt { get; set; }
        public string RemesaHabitualAnt { get; set; }
        public string CondicionExportacion { get; set; }
        public string CodigoExportacion { get; set; }
        public short NoFacturable { get; set; }
        public Guid IdAlbaranPro { get; set; }
        public string CoFibra { get; set; }
    }
}
