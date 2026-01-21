using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace Pos.Core.Entidades.Inventario;

[Keyless]
public partial class VwAlmacenes
{
    public int Id { get; set; }

    [StringLength(50)]
    public string Nombre { get; set; } = null!;

    [StringLength(200)]
    public string? Descripcion { get; set; }

    public int EmpresaId { get; set; }

    [StringLength(200)]
    public string Empresa { get; set; } = null!;

    public bool Activo { get; set; }
}
