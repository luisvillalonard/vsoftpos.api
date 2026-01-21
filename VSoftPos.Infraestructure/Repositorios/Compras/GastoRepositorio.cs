using Pos.Core.Entidades.Compras;
using Pos.Core.Interfaces.Compras;
using Pos.Infraestructure.Contexto;

namespace Pos.Infraestructure.Repositorios.Compras
{
    public class GastoRepositorio : RepositorioGenerico<Gasto, int>, IGastoRepositorio
    {
        public GastoRepositorio(PosContext context) : base(context) { }
    }
}
