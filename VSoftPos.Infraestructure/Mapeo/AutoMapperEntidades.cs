using Pos.Core.Dto;
using Pos.Core.Entidades;
using Pos.Core.Modelos;

namespace Pos.Infraestructure.Mapeo
{
    public class AutoMapperEntidades : AutoMapperBase
    {
        public AutoMapperEntidades()
        {
            CreateMap<Anexo, AnexoDto>()
                .ForMember(dest => dest.Imagen, src => src.MapFrom(p => p.Imagen == null ? null : Utileria.GetBase64FromBytes(p.Imagen, p.Extension)));
            CreateMap<AnexoDto, Anexo>()
                .ForMember(dest => dest.Imagen, src => src.MapFrom(p => p.Imagen == null ? null : Utileria.GetBytesFromBase64(p.Imagen)));

            _ = new AutoMapperAuxiliares();
            _ = new AutoMapperInventario();
            _ = new AutoMapperCompras();
            _ = new AutoMapperVentas();
            _ = new AutoMapperContabilidad();
            _ = new AutoMapperEmpresas();
            _ = new AutoMapperSeguridad();
            _ = new AutoMapperConfiguraciones();
        }
    }
}
