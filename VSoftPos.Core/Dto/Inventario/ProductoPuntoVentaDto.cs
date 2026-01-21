using Pos.Core.Dto.Configuraciones;
using Pos.Core.Dto.Ventas;

namespace Pos.Core.Dto.Inventario
{
    public class ProductoPosDto : FacturaDetalleDto
    {
        public bool EsProducto { get; set; }
        public bool Especifico { get; set; }
        public bool Detallable { get; set; }
        public string? Codigo { get; set; }
        public string? CodigoBarra { get; set; }
        public GrupoDto? Grupo { get; set; }
    }
}
