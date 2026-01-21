using Pos.Core.Entidades.Configuraciones;
using Pos.Core.Interfaces.Configuraciones;
using Pos.Infraestructure.Contexto;

namespace Pos.Infraestructure.Repositorios.Configuraciones
{
    public class FormaPagoRepositorio : RepositorioGenerico<FormaPago, int>, IFormaPagoRepositorio
    {
        public FormaPagoRepositorio(PosContext context) : base(context) { }
    }
}
