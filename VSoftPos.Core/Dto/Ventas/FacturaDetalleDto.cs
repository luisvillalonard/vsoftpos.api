namespace Pos.Core.Dto.Ventas;

public partial class FacturaDetalleDto
{
    public long Id { get; set; }
    public long FacturaId { get; set; }
    public int ProductoId { get; set; }
    public string Producto { get; set; } = null!;
    public decimal Monto { get; set; }
    public int Cantidad { get; set; }
    public decimal Total { get; set; }
    public decimal Itbis { get; set; }
    public decimal Comision { get; set; }
    public int Orden { get; set; }
    public bool Cortesia { get; set; }
}
