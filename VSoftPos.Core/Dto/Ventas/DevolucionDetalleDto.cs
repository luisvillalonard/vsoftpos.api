namespace Pos.Core.Dto.Ventas;

public partial class DevolucionDetalleDto
{
    public long Id { get; set; }
    public long DevolucionId { get; set; }
    public int ProductoId { get; set; }
    public string Producto { get; set; } = null!;
    public int CantidadFacturada { get; set; }
    public int CantidadDevolucion { get; set; }
    public int Orden { get; set; }
    public string? Nota { get; set; }
}
