using System;

namespace TexberAPI.DTOs
{
    public class ClienteDTO
    {
        public string CodigoCliente { get; set; }
        public string SiglaNacion { get; set; }
        public string CifDni { get; set; }
        public string CifEuropeo { get; set; }
        public string CodigoProveedor { get; set; }
        public string CodigoContable { get; set; }
        public string CodigoCategoriaCliente { get; set; }
        public string RazonSocial { get; set; }
        public string Nombre { get; set; }
        public string Domicilio { get; set; }
        public string CodigoSigla { get; set; }
        public string ViaPublica { get; set; }
        public string Numero1 { get; set; }
        public string CodigoPostal { get; set; }
        public string CodigoMunicipio { get; set; }
        public string Municipio { get; set; }
        public string CodigoProvincia { get; set; }
        public string Provincia { get; set; }
        public short CodigoNacion { get; set; }
        public string Nacion { get; set; }
        public string Telefono { get; set; }
        public string CuentaProvision { get; set; }
        public Guid IdCliente { get; set; }
    }
}
