using System;
using System.ComponentModel.DataAnnotations;

namespace TexberAPI.DTOs
{
    public class CabAlbCliDTO
    {
        public string SerieAlbaran { get; set; }
        public int NumeroAlbaran { get; set; }
        public string CodigoCliente { get; set; }
        public string SiglaNacion { get; set; }
        public string CifDni { get; set; }
        public string RazonSocial { get; set; }
        public string RazonSocialEnvios { get; set; }
        public string Nombre { get; set; }
        public string NombreEnvios { get; set; }
        public string Domicilio { get; set; }
        public string DomicilioEnvios { get; set; }
        public string ViaPublicaEnvios { get; set; }
        public string CodigoPostal { get; set; }
        public string CodigoPostalEnvios { get; set; }
        public string CodigoMunicipio { get; set; }
        public string CodigoMunicipioEnvios { get; set; }
        public string Municipio { get; set; }
        public string MunicipioEnvios { get; set; }
        public string Provincia { get; set; }
        public string ProvinciaEnvios { get; set; }
        public short CodigoNacion { get; set; }
        public short CodigoNacionEnvios { get; set; }
        public string Nacion { get; set; }
        public string NacionEnvios { get; set; }
        public string TelefonoEnvios { get; set; }
        public string CodigoContable { get; set; }
    }
}
