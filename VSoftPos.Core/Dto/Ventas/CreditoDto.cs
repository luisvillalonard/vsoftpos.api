namespace Pos.Core.Dto.Ventas;

public partial class CreditoDto
{
    public int Id { get; set; }
    public int ClienteId { get; set; }
    public decimal Monto { get; set; }
    public decimal Deuda { get; set; }
}
