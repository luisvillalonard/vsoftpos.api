using Pos.Core.Entidades.Contabilidad;
using Pos.Core.Interfaces.Contabilidad;
using Pos.Infraestructure.Contexto;

namespace Pos.Infraestructure.Repositorios.Contabilidad
{
    public class BancoRepositorio : RepositorioGenerico<Banco, int>, IBancoRepositorio
    {
        public BancoRepositorio(PosContext context) : base(context) { }
    }
}
