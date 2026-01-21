namespace Pos.Core.Dto.Compras;

public partial class CompraDetalleDto
{
    public int Id { get; set; }
    public int CompraId { get; set; }
    public int ProductoId { get; set; }
    public short EmpaqueId { get; set; }
    public int Cantidad { get; set; }
    public decimal Precio { get; set; }
    public int ImpuestoId { get; set; }
    public decimal Monto { get; set; }
    public int AlmacenId { get; set; }
}
