using Pos.Core.Dto.Configuraciones;
using Pos.Core.Dto.Contabilidad;
using Pos.Core.Entidades.Configuraciones;
using Pos.Core.Entidades.Contabilidad;

namespace Pos.Infraestructure.Mapeo
{
    public class AutoMapperConfiguraciones : AutoMapperBase
    {
        public AutoMapperConfiguraciones()
        {
            CreateMap<Grupo, GrupoDto>();
            CreateMap<GrupoDto, Grupo>();
            
            CreateMap<FormaPago, FormaPagoDto>();
            CreateMap<FormaPagoDto, FormaPago>();
            
            CreateMap<CondicionPago, CondicionPagoDto>();
            CreateMap<CondicionPagoDto, CondicionPago>()
                .ForMember(dest => dest.Cliente, src => src.Ignore())
                .ForMember(dest => dest.Suplidor, src => src.Ignore());
            
            CreateMap<FacturaTipo, FacturaTipoDto>();
            CreateMap<FacturaTipoDto, FacturaTipo>();
            
            CreateMap<Impuesto, ImpuestoDto>();
            CreateMap<ImpuestoDto, Impuesto>();

        }
    }
}
