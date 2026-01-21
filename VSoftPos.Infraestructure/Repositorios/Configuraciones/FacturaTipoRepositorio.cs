using Pos.Core.Entidades.Configuraciones;
using Pos.Core.Interfaces.Configuraciones;
using Pos.Infraestructure.Contexto;

namespace Pos.Infraestructure.Repositorios.Configuraciones
{
    public class FacturaTipoRepositorio : RepositorioGenerico<FacturaTipo, int>, IFacturaTipoRepositorio
    {
        public FacturaTipoRepositorio(PosContext context) : base(context) { }
    }
}
