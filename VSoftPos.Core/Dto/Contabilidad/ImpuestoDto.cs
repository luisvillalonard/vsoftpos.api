namespace Pos.Core.Dto.Contabilidad;

public partial class ImpuestoDto
{
    public int Id { get; set; }
    public string Codigo { get; set; } = null!;
    public string? Nombre { get; set; }
    public decimal Tasa { get; set; }
    public bool Activo { get; set; }
}
