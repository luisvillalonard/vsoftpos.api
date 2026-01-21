using Pos.Core.Entidades.Inventario;
using Pos.Core.Modelos;

namespace Pos.Core.Interfaces.Inventario
{
    public interface IUnidadRepositorio : IRepositorioGenerico<Unidad, int>
    {
        Task<ResponseResult> Todas(RequestFilter request);
    }
}
