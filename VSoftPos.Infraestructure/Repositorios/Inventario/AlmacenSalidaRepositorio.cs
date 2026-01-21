using Pos.Core.Entidades.Inventario;
using Pos.Core.Interfaces.Inventario;
using Pos.Infraestructure.Contexto;

namespace Pos.Infraestructure.Repositorios.Inventario
{
    public class AlmacenSalidaRepositorio : RepositorioGenerico<AlmacenSalida, int>, IAlmacenSalidaRepositorio
    {
        public AlmacenSalidaRepositorio(PosContext context) : base(context) { }
    }
}
