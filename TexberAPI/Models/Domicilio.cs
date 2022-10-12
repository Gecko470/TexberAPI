using System;
using System.Collections.Generic;

#nullable disable

namespace TexberAPI.Models
{
    public partial class Domicilio
    {
        public short CodigoEmpresa { get; set; } = 1;
        public string TipoDomicilio { get; set; }
        public string CodigoCliente { get; set; }
        public short NumeroDomicilio { get; set; }
        public int CodigoTransportista { get; set; }
        public string TipoPortes { get; set; }
        public string Nombre { get; set; }
        public string RazonSocial { get; set; }
        public string RazonSocial2 { get; set; }
        public string CodigoSigla { get; set; }
        public string ViaPublica { get; set; }
        public string Numero1 { get; set; }
        public string Numero2 { get; set; }
        public string Escalera { get; set; }
        public string Piso { get; set; }
        public string Puerta { get; set; }
        public string Letra { get; set; }
        public string Domicilio1 { get; set; }
        public string Domicilio2 { get; set; }
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
        public string HorarioDomicilioLc { get; set; }
        public string PersonaClienteLc { get; set; }
        public string ReferenciaEdi { get; set; }
        public Guid IdDomicilio { get; set; }
    }
}
