using Pos.Core.Dto.Auxiliares;
using Pos.Core.Entidades.Auxiliares;

namespace Pos.Infraestructure.Mapeo
{
    public class AutoMapperAuxiliares : AutoMapperBase
    {
        public AutoMapperAuxiliares()
        {
            CreateMap<Genero, GeneroDto>();
            CreateMap<GeneroDto, Genero>();

            CreateMap<Billete, BilleteDto>();
            CreateMap<BilleteDto, Billete>();
        }
    }
}
