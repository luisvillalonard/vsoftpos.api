using Pos.Core.Entidades.Contabilidad;
using Pos.Core.Interfaces.Contabilidad;
using Pos.Infraestructure.Contexto;

namespace Pos.Infraestructure.Repositorios.Contabilidad
{
    public class CuentaBancoRepositorio : RepositorioGenerico<CuentaBanco, int>, ICuentaBancoRepositorio
    {
        public CuentaBancoRepositorio(PosContext context) : base(context) { }
    }
}
