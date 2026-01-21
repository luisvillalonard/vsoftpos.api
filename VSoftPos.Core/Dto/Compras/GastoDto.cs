using Pos.Core.Dto.Empresas;

namespace Pos.Core.Dto.Compras;

public partial class GastoDto
{
    public int Id { get; set; }
    public GastoTipoDto? Tipo { get; set; }
    public string Fecha { get; set; } = null!;
    public decimal Monto { get; set; }
    public EmpleadoDto? Empleado { get; set; }
    public string? Comentario { get; set; }
    public EmpresaDto? Empresa { get; set; }
    public bool Anulado { get; set; }
}
