namespace Pos.Core.Dto.Ventas;

public partial class FacturaNotaDto
{
    public long Id { get; set; }
    public long FacturaId { get; set; }
    public string Nota { get; set; } = null!;
}
