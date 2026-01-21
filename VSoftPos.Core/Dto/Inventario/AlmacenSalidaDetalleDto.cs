namespace Pos.Core.Dto.Inventario;

public partial class AlmacenSalidaDetalleDto
{
    public int Id { get; set; }
    public int SalidaId { get; set; }
    public int ProductoId { get; set; }
    public int Cantidad { get; set; }
    public decimal Precio { get; set; }
    public decimal Itbis { get; set; }
    public decimal Total { get; set; }
}
