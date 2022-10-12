using AutoMapper;
using TexberAPI.DTOs;
using TexberAPI.Models;

namespace TexberAPI.Helpers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<CabeceraAlbaranProveedor, CabAlbProvDTO>().ReverseMap();
            CreateMap<Proveedore, ProveedorDTO>().ReverseMap();
            CreateMap<Articulo, ArticuloDTO>().ReverseMap();
            CreateMap<LineasAlbaranProveedor, LinAlbProvDTO>().ReverseMap();
            CreateMap<Cliente, ClienteDTO>().ReverseMap();
            CreateMap<CabeceraAlbaranCliente, CabAlbCliDTO>().ReverseMap();
            CreateMap<LineasAlbaranCliente, LinAlbCliDTO>().ReverseMap();
            CreateMap<AcumuladoStock, AcumuladoStockDTO>().ReverseMap();
            CreateMap<Login, LoginDTO>().ReverseMap();
            CreateMap<CoLinea, CO_LineaDTO>().ReverseMap();
            CreateMap<CoProduccionesxLinea, CoProduccionesxLineaDTO>().ReverseMap();
            CreateMap<CoProduccionesxLineaMp, CoProduccionesxLineaMpDTO>().ReverseMap();
            CreateMap<CoProduccionesxLineaPf, CoProduccionesxLineaPfDTO>().ReverseMap();
            CreateMap<MovimientoStock, MovimientoStockDTO>().ReverseMap();
        }
    }
}
