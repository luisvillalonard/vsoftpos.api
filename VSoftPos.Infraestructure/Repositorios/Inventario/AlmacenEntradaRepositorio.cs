using Pos.Core.Entidades.Inventario;
using Pos.Core.Interfaces.Inventario;
using Pos.Infraestructure.Contexto;

namespace Pos.Infraestructure.Repositorios.Inventario
{
    public class AlmacenEntradaRepositorio : RepositorioGenerico<AlmacenEntrada, int>, IAlmacenEntradaRepositorio
    {
        public AlmacenEntradaRepositorio(PosContext context) : base(context) { }
    }
}
