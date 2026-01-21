namespace Pos.Core.Dto.Ventas;

public partial class CotizacionDetalleDto
{
    public int Id { get; set; }
    public int CotizacionId { get; set; }
    public int ProductoId { get; set; }
    public string Producto { get; set; } = null!;
    public decimal Monto { get; set; }
    public int Cantidad { get; set; }
    public decimal Total { get; set; }
    public decimal Itbis { get; set; }
    public int Orden { get; set; }
}
