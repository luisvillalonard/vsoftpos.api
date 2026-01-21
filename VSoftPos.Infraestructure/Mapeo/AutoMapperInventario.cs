using Pos.Core.Dto.Inventario;
using Pos.Core.Entidades.Inventario;

namespace Pos.Infraestructure.Mapeo
{
    public class AutoMapperInventario : AutoMapperBase
    {
        public AutoMapperInventario()
        {
            CreateMap<Almacen, AlmacenDto>().ReverseMap();
            CreateMap<AlmacenEntrada, AlmacenEntradaDto>().ReverseMap();
            CreateMap<AlmacenSalida, AlmacenSalidaDto>().ReverseMap();
            CreateMap<Empaque, EmpaqueDto>().ReverseMap();
            CreateMap<Medida, MedidaDto>().ReverseMap();
            CreateMap<Unidad, UnidadDto>().ReverseMap();
            CreateMap<Producto, ProductoDto>().ReverseMap();
            CreateMap<Stock, StockDto>().ReverseMap();
            CreateMap<Stock, ProductoPosDto>()
                .ForMember(dest => dest.Id, src => src.MapFrom(p => 0))
                .ForMember(dest => dest.ProductoId, src => src.MapFrom(p => p.Producto.Id))
                .ForMember(dest => dest.Producto, src => src.MapFrom(p => p.Producto.Nombre))
                .ForMember(dest => dest.EsProducto, src => src.MapFrom(p => p.Producto.EsProducto))
                .ForMember(dest => dest.Especifico, src => src.MapFrom(p => p.Producto.Especifico))
                .ForMember(dest => dest.Detallable, src => src.MapFrom(p => p.Producto.Detallable))
                .ForMember(dest => dest.Codigo, src => src.MapFrom(p => p.Producto.Codigo))
                .ForMember(dest => dest.CodigoBarra, src => src.MapFrom(p => p.Producto.CodigoBarra))
                .ForMember(dest => dest.Grupo, src => src.MapFrom(p => p.Producto.Grupo))
                .ForMember(dest => dest.Monto, src => src.MapFrom(p => p.Producto.Precio))
                .ForMember(dest => dest.Itbis, src => src.MapFrom(p => p.Producto.Precio * (p.Producto.Impuesto.Tasa / 100)))
                .ForMember(dest => dest.Total, src => src.MapFrom(p => p.Producto.Precio + (p.Producto.Precio * (p.Producto.Impuesto.Tasa / 100))));
            CreateMap<ProductoPosDto, Stock>();
        }
    }
}
