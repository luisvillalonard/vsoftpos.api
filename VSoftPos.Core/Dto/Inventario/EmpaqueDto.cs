using Pos.Core.Dto.Empresas;

namespace Pos.Core.Dto.Inventario;

public partial class EmpaqueDto
{
    public int Id { get; set; }
    public string Nombre { get; set; } = null!;
    public int Unidades { get; set; }
    public bool Activo { get; set; }
}
