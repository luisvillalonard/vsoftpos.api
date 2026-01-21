namespace Pos.Core.Dto.Empresas;

public partial class EmpresaDto
{
    public int Id { get; set; }
    public string Nombre { get; set; } = null!;
    public string Rnc { get; set; } = null!;
    public string Direccion { get; set; } = null!;
    public string? Telefono { get; set; }
    public string? WebSite { get; set; }
    public string? Fax { get; set; }
    public string? Correo { get; set; }
    public AnexoDto? Foto { get; set; }
    public bool Principal { get; set; }
    public int? EmpresaId { get; set; }
    public bool Activa { get; set; }
}
