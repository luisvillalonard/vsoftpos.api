using Pos.Core.Entidades.Contabilidad;
using Pos.Core.Modelos;

namespace Pos.Core.Interfaces.Contabilidad
{
    public interface IComprobanteRepositorio : IRepositorioGenerico<Comprobante, int>
    {
        Task<ResponseResult> Todos(RequestFilter request);
    }
}
