using Pos.Core.Dto.Ventas;
using Pos.Core.Entidades.Ventas;

namespace Pos.Infraestructure.Mapeo
{
    public class AutoMapperVentas : AutoMapperBase
    {
        public AutoMapperVentas()
        {
            CreateMap<ClienteDto, Cliente>()
                .ForMember(dest => dest.FechaIngreso, src => src.MapFrom(p => DateTime.Parse(p.FechaIngreso)))
                .ForMember(dest => dest.Credito, src => src.MapFrom(p => p.Credito == null ? null : new CreditoDto[] { p.Credito }))
                .ForMember(dest => dest.CondicionPago, src => src.Ignore())
                .ForMember(dest => dest.Comprobante, src => src.Ignore());

            CreateMap<Cliente, ClienteDto>()
                .ForMember(dest => dest.FechaIngreso, src => src.MapFrom(p => p.FechaIngreso.ToString(Date_YYYY_MM_DD)))
                .ForMember(dest => dest.Credito, src => src.MapFrom(p => p.Credito.FirstOrDefault()))
                .ForMember(dest => dest.CondicionPago, src => src.MapFrom(p => p.CondicionPago))
                .ForMember(dest => dest.Comprobante, src => src.MapFrom(p => p.Comprobante));

            CreateMap<CreditoDto, Credito>()
                .ForMember(dest => dest.Cliente, src => src.Ignore());
            CreateMap<Credito, CreditoDto>();

            CreateMap<FacturaDto, Factura>()
                .ForMember(dest => dest.EmpresaId, src => src.MapFrom(p => p.Empresa == null ? 0 : p.Empresa.Id))
                .ForMember(dest => dest.ClienteId, src => src.MapFrom(p => p.Cliente == null? 0 : p.Cliente.Id))
                .ForMember(dest => dest.FacturaTipoId, src => src.MapFrom(p => p.FacturaTipo == null ? 0 : p.FacturaTipo.Id))
                .ForMember(dest => dest.FechaEmision, src => src.MapFrom(p => DateTime.Parse(p.FechaEmision)))
                .ForMember(dest => dest.FechaSaldo, src => src.MapFrom(p => string.IsNullOrEmpty(p.FechaSaldo) ? new DateTime?() : DateTime.Parse(p.FechaSaldo)))
                .ForMember(dest => dest.FechaLimitePago, src => src.MapFrom(p => string.IsNullOrEmpty(p.FechaLimitePago) ? new DateTime?() : DateTime.Parse(p.FechaLimitePago)))
                .ForMember(dest => dest.FechaEntrega, src => src.MapFrom(p => string.IsNullOrEmpty(p.FechaEntrega) ? new DateTime?() : DateTime.Parse(p.FechaEntrega)))
                .ForMember(dest => dest.ComprobanteId, src => src.MapFrom(p => p.Comprobante == null? 0 : p.Comprobante.Id))
                .ForMember(dest => dest.FacturaDetalle, src => src.MapFrom(p => p.Items))
                .ForMember(dest => dest.FacturaPago, src => src.MapFrom(p => p.Pagos))
                .ForMember(dest => dest.Empresa, src => src.Ignore())
                .ForMember(dest => dest.Cliente, src => src.Ignore())
                .ForMember(dest => dest.FacturaTipo, src => src.Ignore())
                .ForMember(dest => dest.Comprobante, src => src.Ignore())
                .ForMember(dest => dest.FacturaNota, src => src.Ignore());

            CreateMap<Factura, FacturaDto>()
                .ForMember(dest => dest.Empresa, src => src.MapFrom(p => p.Empresa))
                .ForMember(dest => dest.Cliente, src => src.MapFrom(p => p.Cliente))
                .ForMember(dest => dest.FacturaTipo, src => src.MapFrom(p => p.FacturaTipo))
                .ForMember(dest => dest.FechaEmision, src => src.MapFrom(p => p.FechaEmision.ToString(Date_YYYY_MM_DD)))
                .ForMember(dest => dest.FechaSaldo, src => src.MapFrom(p => !p.FechaSaldo.HasValue ? null : p.FechaSaldo.Value.ToString(Date_YYYY_MM_DD)))
                .ForMember(dest => dest.FechaLimitePago, src => src.MapFrom(p => !p.FechaLimitePago.HasValue ? null : p.FechaLimitePago.Value.ToString(Date_YYYY_MM_DD)))
                .ForMember(dest => dest.FechaEntrega, src => src.MapFrom(p => !p.FechaEntrega.HasValue ? null : p.FechaEntrega.Value.ToString(Date_YYYY_MM_DD)))
                .ForMember(dest => dest.Items, src => src.MapFrom(p => p.FacturaDetalle))
                .ForMember(dest => dest.Notas, src => src.MapFrom(p => p.Nota))
                .ForMember(dest => dest.Pagos, src => src.MapFrom(p => p.FacturaPago));

            CreateMap<FacturaDetalle, FacturaDetalleDto>();
            CreateMap<FacturaDetalleDto, FacturaDetalle>()
                .ForMember(dest => dest.Factura, src => src.Ignore())
                .ForMember(dest => dest.ProductoNavigation, src => src.Ignore());

            CreateMap<FacturaPago, FacturaPagoDto>()
                .ForMember(dest => dest.FormaPago, src => src.MapFrom(p => p.FormaPago));
            CreateMap<FacturaPagoDto, FacturaPago>()
                .ForMember(dest => dest.FormaPagoId, src => src.MapFrom(p => p.FormaPago == null ? 0 : p.FormaPago.Id))
                .ForMember(dest => dest.Factura, src => src.Ignore())
                .ForMember(dest => dest.FormaPago, src => src.Ignore());

        }
    }
}
