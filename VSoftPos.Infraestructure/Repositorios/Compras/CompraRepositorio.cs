using Pos.Core.Entidades.Compras;
using Pos.Core.Interfaces.Compras;
using Pos.Infraestructure.Contexto;

namespace Pos.Infraestructure.Repositorios.Compras
{
    public class CompraRepositorio : RepositorioGenerico<Compra, int>, ICompraRepositorio
    {
        public CompraRepositorio(PosContext context) : base(context) { }
    }
}
