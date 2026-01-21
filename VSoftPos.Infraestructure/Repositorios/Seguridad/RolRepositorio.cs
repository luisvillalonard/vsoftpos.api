using AutoMapper;
using Pos.Core.Dto.Seguridad;
using Pos.Core.Entidades.Seguridad;
using Pos.Core.Enumerables;
using Pos.Core.Interfaces.Seguridad;
using Pos.Core.Modelos;
using Pos.Infraestructure.Contexto;
using Pos.Infraestructure.Helpers;

namespace Pos.Infraestructure.Repositorios.Seguridad
{
    public class RolRepositorio : RepositorioGenerico<Rol, int>, IRolRepositorio
    {
        private readonly IMapper _mapper;
        private readonly IPermisoRepositorio _repoPermiso;

        public RolRepositorio(
            PosContext context, 
            IMapper mapper,
            IPermisoRepositorio repoPermiso) : base(context)
        {
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _repoPermiso = repoPermiso ?? throw new ArgumentNullException(nameof(_repoPermiso));
        }

        public override async Task<ResponseResult> PostAsync(Rol entity)
        {
            var result = await base.FindAsync(
                opt => opt.Nombre.ToLower().Equals(entity.Nombre.ToLower())
            );
            if (!result.Ok)
                return result;

            var rol = _mapper.Map<IEnumerable<Rol>>(result.Datos).FirstOrDefault();
            if (rol is not null)
                return new ResponseResult(false, "Ya existe registrado un rol de usuario con este nombre.");

            // Guardo el rol
            result = await base.PostAsync(entity);
            if (!result.Ok)
                return result;

            // Establezco los nuevos permisos
            var permisos = entity.Permiso
                .Select(permiso => { permiso.RolId = entity.Id; return permiso; })
                .AsEnumerable();

            // Guardo los permisos
            if (permisos.Any())
            {
                result = await _repoPermiso.PostRangeAsync(permisos.ToArray());
                if (!result.Ok)
                    return result;
            }

            return result;
        }

        public override async Task<ResponseResult> PutAsync(Rol entity)
        {
            var result = await base.FindAsync(
                opt => opt.Nombre.ToLower().Equals(entity.Nombre.ToLower())
            );
            if (!result.Ok)
                return result;

            var rol = _mapper.Map<IEnumerable<Rol>>(result.Datos).FirstOrDefault();
            if (rol is not null && rol.Id != entity.Id)
                return new ResponseResult(false, "Ya existe registrado un rol de usuario con este nombre.");

            // Guardo el rol
            result = await base.PutAsync(entity);
            if (!result.Ok)
                return result;

            // Elimino los permisos anteriores
            var resultPermisos = await _repoPermiso.FindAsync(opt => opt.RolId == entity.Id);
            if (resultPermisos is not null && resultPermisos.Ok && resultPermisos.Datos is not null)
            {
                var viejosPermisos = _mapper.Map<IEnumerable<Permiso>>(resultPermisos.Datos).ToArray();
                if (viejosPermisos.Any())
                    await _repoPermiso.DeleteRangeAsync(viejosPermisos);
            }

            // Establezco los nuevos permisos
            var nuevosPermisos = entity.Permiso
                .Select(permiso => { permiso.RolId = entity.Id; return permiso; })
                .ToArray();

            // Guardo los permisos
            if (nuevosPermisos.Any())
            {
                result = await _repoPermiso.PostRangeAsync(nuevosPermisos);
                if (!result.Ok)
                    return result;
            }

            return result;
        }
    }
}
