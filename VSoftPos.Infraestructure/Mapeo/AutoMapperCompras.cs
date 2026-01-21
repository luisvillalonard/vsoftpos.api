using Pos.Core.Dto.Compras;
using Pos.Core.Entidades.Compras;
using System.Globalization;

namespace Pos.Infraestructure.Mapeo
{
    public class AutoMapperCompras : AutoMapperBase
    {
        public AutoMapperCompras()
        {
            CreateMap<Compra, CompraDto>()
                .ForMember(dest => dest.Suplidor, src => src.MapFrom(p => p.Suplidor))
                .ForMember(dest => dest.Empresa, src => src.MapFrom(p => p.Empresa))
                .ForMember(dest => dest.Detalle, src => src.MapFrom(p => p.CompraDetalle))
                .ForMember(dest => dest.Pagos, src => src.MapFrom(p => p.CompraPago));
            CreateMap<CompraDto, Compra>()
                .ForMember(dest => dest.CompraDetalle, src => src.Ignore())
                .ForMember(dest => dest.CompraPago, src => src.Ignore())
                .ForMember(dest => dest.Empresa, src => src.Ignore())
                .ForMember(dest => dest.Suplidor, src => src.Ignore());
            
            CreateMap<CompraDetalle, CompraDetalleDto>();
            CreateMap<CompraDetalleDto, CompraDetalle>()
                .ForMember(dest => dest.Almacen, src => src.Ignore())
                .ForMember(dest => dest.Compra, src => src.Ignore())
                .ForMember(dest => dest.Empaque, src => src.Ignore())
                .ForMember(dest => dest.Impuesto, src => src.Ignore())
                .ForMember(dest => dest.Producto, src => src.Ignore());
            
            CreateMap<CompraPago, CompraPagoDto>();
            CreateMap<CompraPagoDto, CompraPago>()
                .ForMember(dest => dest.Compra, src => src.Ignore());

            CreateMap<GastoTipo, GastoTipoDto>();
            CreateMap<GastoTipoDto, GastoTipo>();

            CreateMap<Gasto, GastoDto>()
                .ForMember(dest => dest.Fecha, src => src.MapFrom(p => p.Fecha.ToString(Date_YYYY_MM_DD)))
                .ForMember(dest => dest.Tipo, src => src.MapFrom(p => p.Tipo))
                .ForMember(dest => dest.Empleado, src => src.MapFrom(p => p.Empleado))
                .ForMember(dest => dest.Empresa, src => src.MapFrom(p => p.Empresa));
            CreateMap<GastoDto, Gasto>()
                .ForMember(dest => dest.Fecha, src => src.MapFrom(p => DateTime.ParseExact(p.Fecha, Date_YYYY_MM_DD, CultureInfo.InvariantCulture)))
                .ForMember(dest => dest.Tipo, src => src.Ignore())
                .ForMember(dest => dest.Empleado, src => src.Ignore())
                .ForMember(dest => dest.Empresa, src => src.Ignore());

            CreateMap<Suplidor, SuplidorDto>()
                .ForMember(dest => dest.FechaIngreso, src => src.MapFrom(p => p.FechaIngreso.ToString(Date_YYYY_MM_DD)))
                .ForMember(dest => dest.CondicionPago, src => src.MapFrom(p => p.CondicionPago));
            CreateMap<SuplidorDto, Suplidor>()
                .ForMember(dest => dest.FechaIngreso, src => src.MapFrom(p => DateTime.Parse(p.FechaIngreso)))
                .ForMember(dest => dest.CondicionPago, src => src.Ignore());
        }
    }
}
