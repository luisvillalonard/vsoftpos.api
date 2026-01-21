using Pos.Core.Entidades.Contabilidad;
using Pos.Core.Modelos;

namespace Pos.Core.Interfaces.Contabilidad
{
    public interface IComprobanteSecuenciaRepositorio : IRepositorioGenerico<ComprobanteSecuencia, int>
    {
        Task<ResponseResult> Todas();
    }
}
