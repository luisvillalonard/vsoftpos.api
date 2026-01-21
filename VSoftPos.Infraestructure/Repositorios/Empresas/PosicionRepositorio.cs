using Pos.Core.Entidades.Empresas;
using Pos.Core.Interfaces.Empresas;
using Pos.Infraestructure.Contexto;

namespace Pos.Infraestructure.Repositorios.Empresas
{
    public class PosicionRepositorio : RepositorioGenerico<Posicion, int>, IPosicionRepositorio
    {
        public PosicionRepositorio(PosContext context) : base(context) { }
    }
}
