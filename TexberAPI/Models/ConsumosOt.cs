using System;
using System.Collections.Generic;

#nullable disable

namespace TexberAPI.Models
{
    public partial class ConsumosOt
    {
        public short CodigoEmpresa { get; set; } = 1;
        public short EjercicioTrabajo { get; set; } = (short)DateTime.Now.Year;
        public int NumeroTrabajo { get; set; }
        public short Orden { get; set; }
        public Guid Identificador { get; set; }
        public string CodigoArticulo { get; set; }
        public short Formula { get; set; }
        public short FormulaComponente { get; set; }
        public string ArticuloComponente { get; set; }
        public string DescripcionArticulo { get; set; }
        public string Descripcion2Articulo { get; set; }
        public string DescripcionLinea { get; set; }
        public short NivelCompuesto { get; set; }
        public byte TipoComponente { get; set; }
        public string CodigoAlmacen { get; set; }
        public string Ubicacion { get; set; }
        public string AlmacenDeposito { get; set; }
        public string UbicacionDeposito { get; set; }
        public string Partida { get; set; }
        public decimal UnidadesNecesarias { get; set; }
        public decimal UnidadesComponente { get; set; }
        public decimal UnidadesUsadas { get; set; }
        public decimal UnidadesEntregadas { get; set; }
        public decimal UnidadesIncidencia { get; set; }
        public decimal Mermas { get; set; }
        public decimal MermasFijas { get; set; }
        public decimal MermasReales { get; set; }
        public string Operacion { get; set; }
        public decimal CosteUnitario { get; set; }
        public decimal CosteComponente { get; set; }
        public decimal CosteRealUnitario { get; set; }
        public decimal CosteRealComponente { get; set; }
        public short AcumulaCoste { get; set; }
        public string UnidadMedida1 { get; set; }
        public string UnidadMedida2 { get; set; }
        public decimal FactorConversion { get; set; }
        public decimal UnidadesNecesarias2 { get; set; }
        public decimal UnidadesComponente2 { get; set; }
        public decimal UnidadesUsadas2 { get; set; }
        public decimal UnidadesEntregadas2 { get; set; }
        public decimal UnidadesIncidencia2 { get; set; }
        public decimal UnidadesEscandallo { get; set; }
        public decimal Mermas2 { get; set; }
        public decimal MermasReales2 { get; set; }
        public decimal IncrementoMermas { get; set; }
        public short RedondeoUnidades { get; set; }
        public short UnidadesFijas { get; set; }
        public short Colores { get; set; }
        public string CodigoColorComponente { get; set; }
        public short GrupoTalla { get; set; }
        public string TallaComponente01 { get; set; }
        public short BloqueoCompraFabricacion { get; set; }
        public string NumeroSerieLc { get; set; }
    }
}
