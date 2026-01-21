using Pos.Core.Dto.Empresas;

namespace Pos.Core.Dto.Inventario;

public partial class AlmacenDto
{
    public int Id { get; set; }
    public string Nombre { get; set; } = null!;
    public string? Descripcion { get; set; }
    public int EmpresaId { get; set; }
    public bool Activo { get; set; }
}
