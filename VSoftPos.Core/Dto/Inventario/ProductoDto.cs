using Pos.Core.Dto.Compras;
using Pos.Core.Dto.Configuraciones;
using Pos.Core.Dto.Empresas;
using Pos.Core.Entidades.Contabilidad;

namespace Pos.Core.Dto.Inventario;

public partial class ProductoDto
{
    public int Id { get; set; }
    public bool EsProducto { get; set; }
    public bool Especifico { get; set; }
    public bool Detallable { get; set; }
    public string? Codigo { get; set; }
    public string Nombre { get; set; } = null!;
    public string? Descripcion { get; set; }
    public string? CodigoBarra { get; set; }
    public int? GrupoId { get; set; }
    public bool SeCompra { get; set; }
    public int? Categoria606 { get; set; }
    public bool SeVende { get; set; }
    public int? Categoria607 { get; set; }
    public int ImpuestoId { get; set; }
    public decimal Costo { get; set; }
    public decimal Precio { get; set; }
    public int Reorden { get; set; }
    public bool VentaSinStock { get; set; }
    public int? CostoCc { get; set; }
    public int? VentaCc { get; set; }
    public int? DescuentoCc { get; set; }
    public StockDto[] Stock { get; set; } = [];
    public long? FotoId { get; set; }
    public bool Activo { get; set; }
}
