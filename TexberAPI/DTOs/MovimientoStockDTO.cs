namespace TexberAPI.DTOs
{
    public class MovimientoStockDTO
    {
        public string CodigoArticulo { get; set; }
        public string CodigoAlmacen { get; set; }
        public string CodigoAlmacen2 { get; set; }
        public string Partida { get; set; }
        public byte TipoMovimiento { get; set; }
        public decimal Unidades { get; set; }
        public decimal Unidades2 { get; set; }
        public string Comentario { get; set; }
        public short UsuarioProceso { get; set; } = 1;
        public decimal UnidadEntrada { get; set; }
        public decimal UnidadStock { get; set; }
        public int Documento { get; set; }
    }
}
