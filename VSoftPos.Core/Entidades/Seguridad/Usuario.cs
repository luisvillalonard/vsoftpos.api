using Microsoft.EntityFrameworkCore;
using Pos.Core.Entidades.Empresas;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Pos.Core.Entidades.Seguridad;

[Index("Acceso", Name = "IDX_Usuario_Acceso")]
[Index("Codigo", Name = "IDX_Usuario_Codigo")]
public partial class Usuario
{
    [Key]
    public int Id { get; set; }

    [StringLength(25)]
    [Unicode(false)]
    public string Acceso { get; set; } = null!;

    [StringLength(1000)]
    [Unicode(false)]
    public string Clave { get; set; } = null!;

    [MaxLength(1024)]
    public byte[] Salt { get; set; } = null!;

    [StringLength(32)]
    [Unicode(false)]
    public string Codigo { get; set; } = null!;

    public bool Cambio { get; set; }

    public int? EmpleadoId { get; set; }

    public int EmpresaId { get; set; }

    public int RolId { get; set; }

    [StringLength(150)]
    [Unicode(false)]
    public string? Correo { get; set; }

    public bool Activo { get; set; }

    [ForeignKey("EmpleadoId")]
    [InverseProperty("Usuario")]
    public virtual Empleado? Empleado { get; set; }

    [ForeignKey("EmpresaId")]
    [InverseProperty("Usuario")]
    public virtual Empresa Empresa { get; set; } = null!;

    [ForeignKey("RolId")]
    [InverseProperty("Usuario")]
    public virtual Rol Rol { get; set; } = null!;
}
