using Pos.Core.Attributos;
using Pos.Core.Dto.Seguridad;
using Pos.Core.Entidades.Seguridad;

namespace Pos.Infraestructure.Mapeo
{
    internal class AutoMapperSeguridad : AutoMapperBase
    {
        public AutoMapperSeguridad()
        {
            CreateMap<Rol, RolDto>()
                .ForMember(dest => dest.Permisos, src => src.MapFrom(p => p.Permiso));
            CreateMap<RolDto, Rol>()
                .ForMember(dest => dest.Permiso, src => src.MapFrom(p => p.Permisos));

            CreateMap<Usuario, UsuarioDto>()
                .ForMember(dest => dest.Empresa, src => src.MapFrom(p => p.Empresa))
                .ForMember(dest => dest.Empleado, src => src.MapFrom(p => p.Empleado))
                .ForMember(dest => dest.Rol, src => src.MapFrom(p => p.Rol));
            CreateMap<UsuarioDto, Usuario>()
                .ForMember(dest => dest.Empresa, src => src.Ignore())
                .ForMember(dest => dest.Empleado, src => src.Ignore())
                .ForMember(dest => dest.Rol, src => src.Ignore());
            
            CreateMap<Usuario, UserApp>()
                .ForMember(dest => dest.Empresa, src => src.MapFrom(p => p.Empresa))
                .ForMember(dest => dest.Empleado, src => src.MapFrom(p => p.Empleado))
                .ForMember(dest => dest.Rol, src => src.MapFrom(p => p.Rol));
            CreateMap<UserApp, Usuario>()
                .ForMember(dest => dest.Empresa, src => src.Ignore())
                .ForMember(dest => dest.Empleado, src => src.Ignore())
                .ForMember(dest => dest.Rol, src => src.Ignore());

            CreateMap<Permiso, PermisoDto>();
            CreateMap<PermisoDto, Permiso>();

            CreateMap<MenuDto, MenuAttribute>();
            CreateMap<MenuAttribute, MenuDto>();
        }
    }
}
