namespace TexberAPI.DTOs
{
    public class ConsumosOT_DTO
    {
        public int NumeroTrabajo { get; set; }
        public string CodigoArticulo { get; set; }
        public string DescripcionArticulo { get; set; }
        public string CodigoAlmacen { get; set; }
        public string Partida { get; set; }
        public decimal UnidadesNecesarias { get; set; }
        public decimal UnidadesUsadas { get; set; }
        public decimal UnidadesEntregadas { get; set; }
    }
}
