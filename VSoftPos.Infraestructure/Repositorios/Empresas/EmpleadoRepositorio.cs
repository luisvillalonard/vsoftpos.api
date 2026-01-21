using Pos.Core.Entidades.Empresas;
using Pos.Core.Interfaces.Empresas;
using Pos.Infraestructure.Contexto;

namespace Pos.Infraestructure.Repositorios.Empresas
{
    public class EmpleadoRepositorio : RepositorioGenerico<Empleado, int>, IEmpleadoRepositorio
    {
        public EmpleadoRepositorio(PosContext context) : base(context) { }
    }
}
