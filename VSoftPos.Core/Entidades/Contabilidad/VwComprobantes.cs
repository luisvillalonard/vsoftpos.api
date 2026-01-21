using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace Pos.Core.Entidades.Contabilidad;

[Keyless]
public partial class VwComprobantes
{
    public int Id { get; set; }

    public int TipoId { get; set; }

    [StringLength(75)]
    [Unicode(false)]
    public string Tipo { get; set; } = null!;

    [StringLength(100)]
    public string Nombre { get; set; } = null!;

    [StringLength(500)]
    public string? Descripcion { get; set; }

    [StringLength(10)]
    [Unicode(false)]
    public string Prefijo { get; set; } = null!;

    public bool Exento { get; set; }

    public int EmpresaId { get; set; }

    [StringLength(200)]
    public string Empresa { get; set; } = null!;

    public bool Activo { get; set; }
}
