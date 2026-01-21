namespace Pos.Core.Dto.Empresas;

public partial class HorarioDto
{
    public int Id { get; set; }
    public string Nombre { get; set; } = null!;
    public string HoraInicio { get; set; } = null!;
    public string HoraFin { get; set; } = null!;
    public EmpresaDto? Empresa { get; set; }
    public bool Activo { get; set; }
}
