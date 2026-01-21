namespace Pos.Core.Dto.Inventario;

public partial class StockDto
{
    public int Id { get; set; }
    public int ProductoId { get; set; }
    public int AlmacenId { get; set; }
    public int Cantidad { get; set; }
    public int Fraccion { get; set; }
}
