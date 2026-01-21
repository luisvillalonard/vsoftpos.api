namespace Pos.Core.Dto.Empresas;

public partial class PosicionDto
{
    public int Id { get; set; }
    public string Nombre { get; set; } = null!;
    public string? Descripcion { get; set; }
    public decimal Sueldo { get; set; }
    public EmpresaDto? Empresa { get; set; }
    public bool Activa { get; set; }
}
