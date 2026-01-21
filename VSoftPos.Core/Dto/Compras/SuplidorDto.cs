using Pos.Core.Dto.Configuraciones;
using Pos.Core.Dto.Empresas;

namespace Pos.Core.Dto.Compras;

public partial class SuplidorDto
{
    public int Id { get; set; }
    public string FechaIngreso { get; set; } = null!;
    public bool EsEmpresa { get; set; }
    public string Nombre { get; set; } = null!;
    public string? Cedula { get; set; }
    public string? Rnc { get; set; }
    public string? Direccion { get; set; }
    public string? Telefono { get; set; }
    public string? Correo { get; set; }
    public bool Informal { get; set; }
    public CondicionPagoDto? CondicionPago { get; set; }
    public bool Credito { get; set; }
    public bool Activo { get; set; }
}
