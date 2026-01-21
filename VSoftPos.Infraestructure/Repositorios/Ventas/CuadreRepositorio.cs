using Pos.Core.Entidades.Ventas;
using Pos.Core.Interfaces.Ventas;
using Pos.Infraestructure.Contexto;

namespace Pos.Infraestructure.Repositorios.Ventas
{
    public class CuadreRepositorio : RepositorioGenerico<Cuadre, int>, ICuadreRepositorio
    {
        public CuadreRepositorio(PosContext context) : base(context) { }
    }
}
