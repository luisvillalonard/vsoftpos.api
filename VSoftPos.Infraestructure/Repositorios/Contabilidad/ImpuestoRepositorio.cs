using Pos.Core.Entidades.Contabilidad;
using Pos.Core.Interfaces.Contabilidad;
using Pos.Infraestructure.Contexto;

namespace Pos.Infraestructure.Repositorios.Contabilidad
{
    public class ImpuestoRepositorio : RepositorioGenerico<Impuesto, int>, IImpuestoRepositorio
    {
        public ImpuestoRepositorio(PosContext context) : base(context) { }
    }
}
