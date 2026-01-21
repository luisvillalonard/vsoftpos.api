namespace Pos.Core.Dto.Ventas;

public partial class CuadreBilleteDto
{
    public long Id { get; set; }
    public long CuadreId { get; set; }
    public int BilleteId { get; set; }
    public string Denominacion { get; set; } = null!;
    public decimal Valor { get; set; }
    public int Cantidad { get; set; }
}
