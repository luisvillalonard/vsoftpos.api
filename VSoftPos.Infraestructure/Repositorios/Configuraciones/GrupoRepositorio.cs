using Pos.Core.Entidades.Configuraciones;
using Pos.Core.Interfaces.Configuraciones;
using Pos.Infraestructure.Contexto;

namespace Pos.Infraestructure.Repositorios.Configuraciones
{
    public class GrupoRepositorio : RepositorioGenerico<Grupo, int>, IGrupoRepositorio
    {
        public GrupoRepositorio(PosContext context) : base(context) { }
    }
}
