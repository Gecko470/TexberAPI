using System;
using System.Collections.Generic;

#nullable disable

namespace TexberAPI.Models
{
    public partial class Almacene
    {
        public short CodigoEmpresa { get; set; } = 1;
        public string CodigoAlmacen { get; set; }
        public string GrupoAlmacen { get; set; }
        public string Responsable { get; set; }
        public string Almacen { get; set; }
        public string Domicilio { get; set; }
        public string CodigoPostal { get; set; }
        public string CodigoMunicipio { get; set; }
        public string Municipio { get; set; }
        public string CodigoProvincia { get; set; }
        public string Provincia { get; set; }
        public string Telefono { get; set; }
        public string Fax { get; set; }
        public short AgruparMovimientos { get; set; }
        public string IdDelegacion { get; set; }
        public Guid IdAlmacen { get; set; }
        public string CoCodigoAlmacenSauleda { get; set; }
    }
}
