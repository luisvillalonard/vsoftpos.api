using Pos.Core.Entidades.Ventas;
using Pos.Core.Interfaces.Ventas;
using Pos.Infraestructure.Contexto;

namespace Pos.Infraestructure.Repositorios.Ventas
{
    public class DevolucionRepositorio : RepositorioGenerico<Devolucion, int>, IDevolucionRepositorio
    {
        public DevolucionRepositorio(PosContext context) : base(context) { }
    }
}
