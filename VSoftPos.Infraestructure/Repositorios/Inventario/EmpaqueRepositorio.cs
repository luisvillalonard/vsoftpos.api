using Pos.Core.Entidades.Inventario;
using Pos.Core.Interfaces.Inventario;
using Pos.Infraestructure.Contexto;

namespace Pos.Infraestructure.Repositorios.Inventario
{
    public class EmpaqueRepositorio : RepositorioGenerico<Empaque, int>, IEmpaqueRepositorio
    {
        public EmpaqueRepositorio(PosContext context) : base(context) { }
    }
}
