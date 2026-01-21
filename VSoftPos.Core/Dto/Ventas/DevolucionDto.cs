namespace Pos.Core.Dto.Ventas;

public partial class DevolucionDto
{
    public long Id { get; set; }
    public long FacturaId { get; set; }
    public string Fecha { get; set; } = null!;
    public string? Nota { get; set; }
    public bool Anulada { get; set; }
}
