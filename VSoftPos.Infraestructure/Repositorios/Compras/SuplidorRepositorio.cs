using Pos.Core.Entidades.Compras;
using Pos.Core.Interfaces.Compras;
using Pos.Infraestructure.Contexto;

namespace Pos.Infraestructure.Repositorios.Compras
{
    public class SuplidorRepositorio : RepositorioGenerico<Suplidor, int>, ISuplidorRepositorio
    {
        public SuplidorRepositorio(PosContext context) : base(context) { }
    }
}
