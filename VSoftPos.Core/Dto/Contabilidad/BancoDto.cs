namespace Pos.Core.Dto.Contabilidad;

public partial class BancoDto
{
    public int Id { get; set; }
    public required string Nombre { get; set; }
    public string? Descripcion { get; set; }
    public bool Activo { get; set; }
}
