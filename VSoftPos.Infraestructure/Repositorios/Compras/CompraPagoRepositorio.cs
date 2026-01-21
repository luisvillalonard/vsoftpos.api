using Pos.Core.Entidades.Compras;
using Pos.Core.Interfaces.Compras;
using Pos.Infraestructure.Contexto;

namespace Pos.Infraestructure.Repositorios.Compras
{
    public class CompraPagoRepositorio : RepositorioGenerico<CompraPago, int>, ICompraPagoRepositorio
    {
        public CompraPagoRepositorio(PosContext context) : base(context) { }
    }
}
