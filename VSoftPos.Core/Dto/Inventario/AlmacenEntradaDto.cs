namespace Pos.Core.Dto.Inventario;

public partial class AlmacenEntradaDto
{
    public int Id { get; set; }
    public int AlmacenId { get; set; }
    public string Fecha { get; set; } = null!;
    public string? Nota { get; set; }
    public bool Anulada { get; set; }
}
