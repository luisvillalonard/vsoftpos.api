using Pos.Core.Entidades.Compras;
using Pos.Core.Interfaces.Compras;
using Pos.Infraestructure.Contexto;

namespace Pos.Infraestructure.Repositorios.Compras
{
    public class GastoTipoRepositorio : RepositorioGenerico<GastoTipo, int>, IGastoTipoRepositorio
    {
        public GastoTipoRepositorio(PosContext context) : base(context) { }
    }
}
