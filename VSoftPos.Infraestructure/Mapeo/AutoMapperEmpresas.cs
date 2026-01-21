using Pos.Core.Dto.Empresas;
using Pos.Core.Entidades.Empresas;

namespace Pos.Infraestructure.Mapeo
{
    public class AutoMapperEmpresas : AutoMapperBase
    {
        public AutoMapperEmpresas()
        {
            CreateMap<Empresa, EmpresaDto>();
            CreateMap<EmpresaDto, Empresa>();

            CreateMap<Empleado, EmpleadoDto>()
                .ForMember(dest => dest.Empresa, src => src.MapFrom(p => p.Empresa));
            CreateMap<EmpleadoDto, Empleado>()
                .ForMember(dest => dest.Empresa, src => src.Ignore());

            CreateMap<Horario, HorarioDto>()
                .ForMember(dest => dest.Empresa, src => src.MapFrom(p => p.Empresa))
                .ForMember(dest => dest.HoraInicio, src => src.MapFrom(p => p.HoraInicio.ToString(Time_HH_MM_SS)))
                .ForMember(dest => dest.HoraFin, src => src.MapFrom(p => p.HoraFin.ToString(Time_HH_MM_SS)));
            CreateMap<HorarioDto, Horario>()
                .ForMember(dest => dest.HoraInicio, src => src.MapFrom(p => TimeSpan.Parse(p.HoraInicio)))
                .ForMember(dest => dest.HoraFin, src => src.MapFrom(p => TimeSpan.Parse(p.HoraFin)))
                .ForMember(dest => dest.Empresa, src => src.Ignore());

            CreateMap<Posicion, PosicionDto>()
                .ForMember(dest => dest.Empresa, src => src.MapFrom(p => p.Empresa));
            CreateMap<PosicionDto, Posicion>()
                .ForMember(dest => dest.Empresa, src => src.Ignore());

            CreateMap<Empleado, EmpleadoDto>()
                .ForMember(dest => dest.FechaEntrada, src => src.MapFrom(p => !p.FechaEntrada.HasValue ? null : p.FechaEntrada.Value.ToString(Date_YYYY_MM_DD)))
                .ForMember(dest => dest.FechaSalida, src => src.MapFrom(p => !p.FechaSalida.HasValue ? null : p.FechaSalida.Value.ToString(Date_YYYY_MM_DD)))
                .ForMember(dest => dest.Horario, src => src.MapFrom(p => p.Horario))
                .ForMember(dest => dest.Posicion, src => src.MapFrom(p => p.Posicion))
                .ForMember(dest => dest.Empresa, src => src.MapFrom(p => p.Empresa));
            CreateMap<EmpleadoDto, Empleado>()
                .ForMember(dest => dest.FechaEntrada, src => src.MapFrom(p => string.IsNullOrEmpty(p.FechaEntrada) ? new DateTime?() : DateTime.Parse(p.FechaEntrada)))
                .ForMember(dest => dest.FechaSalida, src => src.MapFrom(p => string.IsNullOrEmpty(p.FechaSalida) ? new DateTime?() : DateTime.Parse(p.FechaSalida)))
                .ForMember(dest => dest.Empresa, src => src.Ignore());

        }
    }
}
