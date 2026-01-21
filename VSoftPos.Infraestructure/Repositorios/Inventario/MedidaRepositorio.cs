using Pos.Core.Entidades.Inventario;
using Pos.Core.Interfaces.Inventario;
using Pos.Infraestructure.Contexto;

namespace Pos.Infraestructure.Repositorios.Inventario
{
    public class MedidaRepositorio : RepositorioGenerico<Medida, int>, IMedidaRepositorio
    {
        public MedidaRepositorio(PosContext context) : base(context) { }
    }
}
