using Pos.Core.Dto.Empresas;

namespace Pos.Core.Dto.Contabilidad;

public partial class ComprobanteDto
{
    public int Id { get; set; }
    public int TipoId { get; set; }
    public string Nombre { get; set; } = null!;
    public string? Descripcion { get; set; }
    public string Prefijo { get; set; } = null!;
    public bool Exento { get; set; }
    public int EmpresaId { get; set; }
    public bool Activo { get; set; }
}
