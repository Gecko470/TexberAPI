﻿using System;
using System.Collections.Generic;

#nullable disable

namespace TexberAPI.Models
{
    public partial class CabeceraAlbaranCliente
    {
        public short CodigoEmpresa { get; set; } = 1;
        public string IdDelegacion { get; set; }
        public short EjercicioAlbaran { get; set; } = (short)DateTime.Now.Year;
        public string SerieAlbaran { get; set; }
        public int NumeroAlbaran { get; set; }
        public DateTime FechaAlbaran { get; set; } = DateTime.Now;
        public string CodigoCliente { get; set; }
        public string CodigoCadena { get; set; }
        public short NumeroLineas { get; set; }
        public string SiglaNacion { get; set; }
        public string CifDni { get; set; }
        public string CifEuropeo { get; set; }
        public string RazonSocial { get; set; }
        public string RazonSocialEnvios { get; set; }
        public string RazonSocial2 { get; set; }
        public string RazonSocial2Envios { get; set; }
        public string Nombre { get; set; }
        public string NombreEnvios { get; set; }
        public string Domicilio { get; set; }
        public string DomicilioEnvios { get; set; }
        public string Domicilio2 { get; set; }
        public string Domicilio2Envios { get; set; }
        public string ViaPublicaEnvios { get; set; }
        public string CodigoPostal { get; set; }
        public string CodigoPostalEnvios { get; set; }
        public string CodigoMunicipio { get; set; }
        public string CodigoMunicipioEnvios { get; set; }
        public string Municipio { get; set; }
        public string MunicipioEnvios { get; set; }
        public string ColaMunicipio { get; set; }
        public string ColaMunicipioEnvios { get; set; }
        public string CodigoProvincia { get; set; }
        public string CodigoProvinciaEnvios { get; set; }
        public string Provincia { get; set; }
        public string ProvinciaEnvios { get; set; }
        public short CodigoNacion { get; set; }
        public short CodigoNacionEnvios { get; set; }
        public string Nacion { get; set; }
        public string NacionEnvios { get; set; }
        public string TelefonoEnvios { get; set; }
        public string FaxEnvios { get; set; }
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
        public int CodigoTransportistaEnvios { get; set; }
        public string TipoPortesEnvios { get; set; }
        public byte CodigoTransaccion { get; set; }
        public short CodigoRetencion { get; set; }
        public short CodigoTipoEfecto { get; set; }
        public short DomicilioEnvio { get; set; }
        public short DomicilioFactura { get; set; }
        public short DomicilioRecibo { get; set; }
        public string CodigoDefinicion { get; set; }
        public string CodigoContable { get; set; }
        public string RemesaHabitual { get; set; }
        public string CodigoBanco { get; set; }
        public string CodigoAgencia { get; set; }
        public string Dc { get; set; }
        public string Ccc { get; set; }
        public string Iban { get; set; }
        public short CodigoTerritorio { get; set; }
        public string IndicadorIva { get; set; }
        public short IvaIncluido { get; set; }
        public byte GrupoIva { get; set; }
        public short TarifaPrecio { get; set; }
        public short TarifaDescuento { get; set; }
        public int CodigoComisionista { get; set; }
        public int CodigoComisionista2 { get; set; }
        public int CodigoComisionista3 { get; set; }
        public int CodigoComisionista4 { get; set; }
        public int CodigoJefeVenta { get; set; }
        public int CodigoJefeZona { get; set; }
        public int CodigoZona { get; set; }
        public string CodigoCanal { get; set; }
        public string CodigoRuta { get; set; }
        public string CodigoProyecto { get; set; }
        public string CodigoSeccion { get; set; }
        public string CodigoDepartamento { get; set; }
        public short Bloqueo { get; set; }
        public short StatusFacturado { get; set; }
        public short StatusListadoAlbaran { get; set; }
        public short StatusEstadis { get; set; }
        public short StatusEtiquetaEnvio { get; set; }
        public short StatusAlbaranEnvio { get; set; }
        public short StatusAbono { get; set; }
        public short StatusContabilizado { get; set; }
        public short StatusAnalitica { get; set; }
        public short AlbaranValorado { get; set; }
        public byte PeriodicidadFacturas { get; set; }
        public short AgruparAlbaranes { get; set; }
        public byte CopiasAlbaran { get; set; }
        public byte CopiasFactura { get; set; }
        public short PackingList { get; set; }
        public string MascaraAlbaran { get; set; }
        public string MascaraFactura { get; set; }
        public string ObservacionesCliente { get; set; }
        public string ObservacionesAlbaran { get; set; }
        public string ObservacionesFactura { get; set; }
        public decimal Descuento { get; set; }
        public decimal ProntoPago { get; set; }
        public decimal Financiacion { get; set; }
        public decimal Retencion { get; set; }
        public decimal Rappel { get; set; }
        public decimal Comision { get; set; }
        public decimal Comision2 { get; set; }
        public decimal Comision3 { get; set; }
        public decimal Comision4 { get; set; }
        public decimal ComisionSobreVenta { get; set; }
        public decimal ComisionSobreZona { get; set; }
        public string SuPedido { get; set; }
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
        public decimal FactorCambio { get; set; }
        public short MantenerCambio { get; set; }
        public int Bultos { get; set; }
        public decimal ImporteEnvases { get; set; }
        public decimal ImporteEnvasesDivisa { get; set; }
        public decimal ImportePortes { get; set; }
        public decimal ImportePortesDivisa { get; set; }
        public decimal ImporteCambio { get; set; }
        public decimal ImporteCambioViejo { get; set; }
        public decimal ImporteCoste { get; set; }
        public decimal ImporteBruto { get; set; }
        public decimal ImporteBrutoDivisa { get; set; }
        public decimal ImporteDescuentoLineas { get; set; }
        public decimal ImporteDtoLineasDivisa { get; set; }
        public decimal ImporteNetoLineas { get; set; }
        public decimal ImporteNetoLineasDivisa { get; set; }
        public decimal ImporteDescuento { get; set; }
        public decimal ImporteDescuentoDivisa { get; set; }
        public decimal BaseComision { get; set; }
        public decimal BaseComisionDivisa { get; set; }
        public decimal ImporteComision { get; set; }
        public decimal ImporteComision2 { get; set; }
        public decimal ImporteComision3 { get; set; }
        public decimal ImporteComision4 { get; set; }
        public decimal ImporteComisionJefeVentas { get; set; }
        public decimal ImporteComisionJefeZona { get; set; }
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
        public decimal ImporteFactura { get; set; }
        public decimal ImporteFacturaDivisa { get; set; }
        public decimal ImporteRetencion { get; set; }
        public decimal ImporteRetencionDivisa { get; set; }
        public decimal ImporteLiquido { get; set; }
        public decimal ImporteLiquidoDivisa { get; set; }
        public decimal ImporteRappel { get; set; }
        public decimal ImporteRappelDivisa { get; set; }
        public string CodigoExportacion { get; set; }
        public string CondicionExportacion { get; set; }
        public string ObservacionExportacion { get; set; }
        public string ObservacionExportacion2 { get; set; }
        public string PuertoOrigen { get; set; }
        public string PuertoDestino { get; set; }
        public decimal PesoBruto { get; set; }
        public decimal PesoNeto { get; set; }
        public decimal Volumen { get; set; }
        public decimal ImporteFletes { get; set; }
        public decimal ImporteFletesDivisa { get; set; }
        public decimal ImporteSeguro { get; set; }
        public decimal ImporteSeguroDivisa { get; set; }
        public decimal GastosAduana { get; set; }
        public decimal GastosAduanaDivisa { get; set; }
        public short EjercicioFacturaOriginal { get; set; }
        public string SerieFacturaOriginal { get; set; }
        public int NumeroFacturaOriginal { get; set; }
        public string CodigoTipoOperacionLc { get; set; }
        public string CodigoTipoOperacionOrigenLc { get; set; }
        public string CodigoDivisionLc { get; set; }
        public string CodigoAmbitoClienteLc { get; set; }
        public string CodigoClaseClienteLc { get; set; }
        public string CodigoSubclaseClienteLc { get; set; }
        public string CodigoTipoClienteLc { get; set; }
        public string CodigoGrupoClienteLc { get; set; }
        public string CodigoActividadLc { get; set; }
        public string CodigoSubactividadLc { get; set; }
        public int ComercialAsignadoLc { get; set; }
        public short FacturarCompletoLc { get; set; }
        public int IdFacturarCompletoLc { get; set; }
        public int IdFacturacionConjuntaLc { get; set; }
        public string IdDelegacionCentralLc { get; set; }
        public short NumeroCaja { get; set; }
        public int NumeroInterno { get; set; }
        public string ReferenciaEdi { get; set; }
        public string CodigoMotivoAbonoLc { get; set; }
        public short EjercicioAlbaranOriginalLc { get; set; }
        public string SerieAlbaranOriginalLc { get; set; }
        public int NumeroAlbaranOriginalLc { get; set; }
        public short StatusEnvioXml { get; set; }
        public short StatusCreadoXml { get; set; }
        public short TipoNuevaFra { get; set; }
        public string GenerarFactura { get; set; }
        public decimal ImporteAcuentaA { get; set; }
        public decimal ImporteAcuentaAdivisa { get; set; }
        public decimal ImporteConsumidoA { get; set; }
        public decimal ImporteConsumidoAdivisa { get; set; }
        public short EjercicioAlbaranDevolucionA { get; set; }
        public string SerieAlbaranDevolucionA { get; set; }
        public int NumeroAlbaranDevolucionA { get; set; }
        public decimal ImportePendienteAac { get; set; }
        public decimal ImportePendienteAacdivisa { get; set; }
        public short Entrega { get; set; }
        public byte DesgloseContenido { get; set; }
        public byte CalculoDeBultos { get; set; }
        public decimal PorMargenBeneficio { get; set; }
        public decimal MargenBeneficio { get; set; }
        public short EjercicioExpediente { get; set; }
        public string SerieExpediente { get; set; }
        public int NumeroExpediente { get; set; }
        public short OrigenDespacho { get; set; }
        public decimal ImporteProvisiones { get; set; }
        public decimal ImporteProvisionesNf { get; set; }
        public decimal ImporteSuplidos { get; set; }
        public decimal ImporteProvisionesDivisa { get; set; }
        public decimal ImporteProvisionesNfdivisa { get; set; }
        public decimal ImporteSuplidosDivisa { get; set; }
        public string CodigoContableAnt { get; set; }
        public string RemesaHabitualAnt { get; set; }
        public string AnaLote { get; set; }
        public string AnaCapitulo { get; set; }
        public short EsTicket { get; set; }
        public short NumeroTerminalSr { get; set; }
        public short NumeroTurnoSr { get; set; }
        public DateTime FechaCreacion { get; set; } = DateTime.Now;
        public decimal HoraCreacion { get; set; }
        public short NoFacturable { get; set; }
        public Guid MovConta { get; set; }
        public string ObservacionesWeb { get; set; }
        public int SuPedidoWeb { get; set; }
        public Guid IdAlbaranCli { get; set; }
        public short EnvioEfactura { get; set; }
        public string Matricula { get; set; }
        public string Matricula2 { get; set; }
        public string ReferenciaMandato { get; set; }
        public string SuContrato { get; set; }
        public short PagoInmediato { get; set; }
    }
}
