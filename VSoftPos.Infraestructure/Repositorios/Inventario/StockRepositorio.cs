using Pos.Core.Entidades.Inventario;
using Pos.Core.Interfaces.Inventario;
using Pos.Infraestructure.Contexto;

namespace Pos.Infraestructure.Repositorios.Inventario
{
    public class StockRepositorio : RepositorioGenerico<Stock, int>, IStockRepositorio
    {
        public StockRepositorio(PosContext context) : base(context) { }
    }
}
