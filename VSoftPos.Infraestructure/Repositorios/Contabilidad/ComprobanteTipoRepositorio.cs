using Pos.Core.Entidades.Contabilidad;
using Pos.Core.Interfaces.Contabilidad;
using Pos.Infraestructure.Contexto;

namespace Pos.Infraestructure.Repositorios.Contabilidad
{
    public class ComprobanteTipoRepositorio : RepositorioGenerico<ComprobanteTipo, int>, IComprobanteTipoRepositorio
    {
        public ComprobanteTipoRepositorio(PosContext context) : base(context) { }
    }
}
