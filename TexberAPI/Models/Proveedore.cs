using System;
using System.Collections.Generic;

#nullable disable

namespace TexberAPI.Models
{
    public partial class Proveedore
    {
        public short CodigoEmpresa { get; set; } = 1;
        public string IdDelegacion { get; set; }
        public string CodigoProveedor { get; set; }
        public string SiglaNacion { get; set; }
        public string CifDni { get; set; }
        public string CifEuropeo { get; set; }
        public string RazonSocial { get; set; }
        public string RazonSocial2 { get; set; }
        public string Nombre { get; set; }
        public string Domicilio { get; set; }
        public string Domicilio2 { get; set; }
        public string Actividad { get; set; }
        public string Cargo1 { get; set; }
        public string Nombre1 { get; set; }
        public string Cargo2 { get; set; }
        public string Nombre2 { get; set; }
        public string Cargo3 { get; set; }
        public string Nombre3 { get; set; }
        public string TipoProveedor { get; set; }
        public string Marca { get; set; }
        public string ObservacionesProveedor { get; set; }
        public string Comentarios { get; set; }
        public string CodigoContable { get; set; }
        public string CodigoDefinicion { get; set; }
        public short CodigoCondiciones { get; set; }
        public string FormadePago { get; set; }
        public string CodigoBanco { get; set; }
        public string CodigoAgencia { get; set; }
        public string Dc { get; set; }
        public string Ccc { get; set; }
        public string Iban { get; set; }
        public short BloqueoPedido { get; set; }
        public short BloqueoCompra { get; set; }
        public short DomicilioRecibo { get; set; }
        public string CodigoCliente { get; set; }
        public string ClienteVenta { get; set; }
        public string CodigoProyecto { get; set; }
        public string CodigoSeccion { get; set; }
        public string CodigoDepartamento { get; set; }
        public string AlmacenDeposito { get; set; }
        public string CodigoIdioma { get; set; }
        public string CodigoDivisa { get; set; }
        public string CodigoCanal { get; set; }
        public int CodigoZona { get; set; }
        public int CodigoTransportista { get; set; }
        public string TipoPortes { get; set; }
        public short TarifaPrecio { get; set; }
        public short TarifaDescuento { get; set; }
        public byte GrupoIva { get; set; }
        public string IndicadorIva { get; set; }
        public string MascaraOferta { get; set; }
        public string MascaraPedido { get; set; }
        public string MascaraAlbaran { get; set; }
        public string MascaraTalones { get; set; }
        public string MascaraFactura { get; set; }
        public string SerieOferta { get; set; }
        public string SeriePedido { get; set; }
        public string SerieAlbaran { get; set; }
        public short AgruparAlbaranes { get; set; }
        public short AgruparAbonos { get; set; }
        public short MantenerCambio { get; set; }
        public short FinanciacionSobreBase { get; set; }
        public decimal Descuento { get; set; }
        public decimal ProntoPago { get; set; }
        public decimal Retencion { get; set; }
        public decimal Rappel { get; set; }
        public decimal Financiacion { get; set; }
        public string CodigoSigla { get; set; }
        public string ViaPublica { get; set; }
        public string Numero1 { get; set; }
        public string Numero2 { get; set; }
        public string Escalera { get; set; }
        public string Piso { get; set; }
        public string Puerta { get; set; }
        public string Letra { get; set; }
        public string CodigoPostal { get; set; }
        public string CodigoMunicipio { get; set; }
        public string Municipio { get; set; }
        public string ColaMunicipio { get; set; }
        public string CodigoProvincia { get; set; }
        public string Provincia { get; set; }
        public short CodigoNacion { get; set; }
        public string Nacion { get; set; }
        public string Telefono { get; set; }
        public string Telefono2 { get; set; }
        public string Telefono3 { get; set; }
        public string Fax { get; set; }
        public string Email1 { get; set; }
        public string Email2 { get; set; }
        public short BajaEmpresaLc { get; set; }
        public DateTime? FechaBajaLc { get; set; }
        public decimal RiesgoMaximo { get; set; }
        public string ReferenciaEdi { get; set; }
        public string ReferenciadelCliente { get; set; }
        public string CodigoNaturaleza { get; set; }
        public string CodigoTransporte { get; set; }
        public string CodigoPuerto { get; set; }
        public string CodigoRegimenEstadistico { get; set; }
        public short RetencionConIva { get; set; }
        public string CodigoContableAnt { get; set; }
        public string CondicionExportacion { get; set; }
        public string CodigoExportacion { get; set; }
        public DateTime? FechaNacimiento { get; set; }
        public Guid IdProveedor { get; set; }
        public string Social1 { get; set; }
        public string Social2 { get; set; }
        public string Social3 { get; set; }
        public string Social4 { get; set; }
        public string TelefonoAccion { get; set; }
        public string Telefono2Accion { get; set; }
        public string Telefono3Accion { get; set; }
        public string Social1Accion { get; set; }
        public string Social2Accion { get; set; }
        public string Social3Accion { get; set; }
        public string Social4Accion { get; set; }
        public short ExcluirPorLopdlc { get; set; }
        public short StatusWf { get; set; }
    }
}
