using Pos.Core.Dto.Empresas;

namespace Pos.Core.Dto.Seguridad;

public partial class UsuarioDto
{
    public int Id { get; set; }
    public required string Acceso { get; set; }
    public required string Codigo { get; set; }
    public EmpleadoDto? Empleado { get; set; }
    public required EmpresaDto Empresa { get; set; }
    public required RolDto Rol { get; set; }
    public string? Correo { get; set; }
    public bool Cambio { get; set; }
    public bool Activo { get; set; }
}
