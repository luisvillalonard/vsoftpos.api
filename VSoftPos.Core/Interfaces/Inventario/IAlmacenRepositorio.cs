using Pos.Core.Entidades.Inventario;
using Pos.Core.Modelos;

namespace Pos.Core.Interfaces.Inventario
{
    public interface IAlmacenRepositorio : IRepositorioGenerico<Almacen, int>
    {
        Task<ResponseResult> Todos();
    }
}
