using Pos.Core.Entidades.Auxiliares;
using Pos.Core.Interfaces.Auxiliares;
using Pos.Infraestructure.Contexto;

namespace Pos.Infraestructure.Repositorios.Auxiliares
{
    public class BilleteRepositorio : RepositorioGenerico<Billete, int>, IBilleteRepositorio
    {
        public BilleteRepositorio(PosContext context) : base(context) { }
    }
}
