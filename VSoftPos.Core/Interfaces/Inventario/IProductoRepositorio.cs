using Pos.Core.Entidades.Inventario;
using Pos.Core.Modelos;

namespace Pos.Core.Interfaces.Inventario
{
    public interface IProductoRepositorio : IRepositorioGenerico<Producto, int>
    {
        Task<ResponseResult> Todos(RequestFilter request);
    }
}
