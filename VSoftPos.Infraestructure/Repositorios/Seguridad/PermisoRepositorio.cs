using Pos.Core.Entidades.Seguridad;
using Pos.Core.Interfaces.Seguridad;
using Pos.Infraestructure.Contexto;

namespace Pos.Infraestructure.Repositorios.Seguridad
{
    public class PermisoRepositorio : RepositorioGenerico<Permiso, int>, IPermisoRepositorio
    {
        public PermisoRepositorio(PosContext context) : base(context) { }
    }
}
