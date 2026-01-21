using Pos.Core.Entidades.Empresas;
using Pos.Core.Interfaces.Empresas;
using Pos.Infraestructure.Contexto;

namespace Pos.Infraestructure.Repositorios.Empresas
{
    public class EmpresaRepositorio : RepositorioGenerico<Empresa, int>, IEmpresaRepositorio
    {
        public EmpresaRepositorio(PosContext context) : base(context) { }
    }
}
