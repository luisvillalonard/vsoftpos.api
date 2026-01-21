using Pos.Core.Entidades.Auxiliares;
using Pos.Core.Interfaces.Auxiliares;
using Pos.Infraestructure.Contexto;

namespace Pos.Infraestructure.Repositorios.Auxiliares
{
    public class GeneroRepositorio : RepositorioGenerico<Genero, int>, IGeneroRepositorio
    {
        public GeneroRepositorio(PosContext context) : base(context) { }
    }
}
