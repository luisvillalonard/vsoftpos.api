using Pos.Core.Dto.Contabilidad;
using Pos.Core.Entidades.Contabilidad;

namespace Pos.Infraestructure.Mapeo
{
    public class AutoMapperContabilidad : AutoMapperBase
    {
        public AutoMapperContabilidad()
        {
            CreateMap<Banco, BancoDto>().ReverseMap();
            CreateMap<CatalogoCc, CatalogoCcDto>().ReverseMap();
            CreateMap<ComprobanteTipo, ComprobanteTipoDto>().ReverseMap();
            CreateMap<Comprobante, ComprobanteDto>().ReverseMap();
            
            CreateMap<CuentaBanco, CuentaBancoDto>()
                .ForMember(dest => dest.FechaApertura, src => src.MapFrom(p => !p.FechaApertura.HasValue ? null : p.FechaApertura.Value.ToString(Date_YYYY_MM_DD)))
                .ForMember(dest => dest.Banco, src => src.MapFrom(p => p.Banco));
            CreateMap<CuentaBancoDto, CuentaBanco>()
                .ForMember(dest => dest.FechaApertura, src => src.MapFrom(p => string.IsNullOrEmpty(p.FechaApertura) ? new DateTime?() : DateTime.Parse(p.FechaApertura)))
                .ForMember(dest => dest.Banco, src => src.Ignore());

            CreateMap<ComprobanteSecuencia, ComprobanteSecuenciaDto>()
                .ForMember(dest => dest.FechaVence, src => src.MapFrom(p => !p.FechaVence.HasValue ? null : p.FechaVence.Value.ToString(Date_YYYY_MM_DD)));
            CreateMap<ComprobanteSecuenciaDto, ComprobanteSecuencia>()
                .ForMember(dest => dest.FechaVence, src => src.MapFrom(p => string.IsNullOrEmpty(p.FechaVence) ? new DateTime?() : DateTime.Parse(p.FechaVence)));
        }
    }
}
