namespace Pos.Core.Dto.Compras;

public partial class GastoTipoDto
{
    public short Id { get; set; }
    public string Nombre { get; set; } = null!;
    public string? Descripcion { get; set; }
    public bool Activo { get; set; }
}
