using Pos.Core.Entidades.Ventas;
using Pos.Core.Interfaces.Ventas;
using Pos.Infraestructure.Contexto;

namespace Pos.Infraestructure.Repositorios.Ventas
{
    public class CotizacionRepositorio : RepositorioGenerico<Cotizacion, int>, ICotizacionRepositorio
    {
        public CotizacionRepositorio(PosContext context) : base(context) { }
    }
}
