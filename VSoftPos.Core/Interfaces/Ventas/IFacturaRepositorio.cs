using Pos.Core.Entidades.Ventas;
using Pos.Core.Modelos;

namespace Pos.Core.Interfaces.Ventas
{
    public interface IFacturaRepositorio : IRepositorioGenerico<Factura, long>
    {
        Task<ResponseResult> PostPagoAsync(FacturaPago[] items);
    }
}
