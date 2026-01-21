namespace Pos.Core.Dto.Compras;

public partial class CompraPagoDto
{
    public int Id { get; set; }
    public int CompraId { get; set; }
    public decimal Monto { get; set; }
    public string Fecha { get; set; } = null!;
    public string? NumeroRecibo { get; set; }
    public bool Anulado { get; set; }
}
