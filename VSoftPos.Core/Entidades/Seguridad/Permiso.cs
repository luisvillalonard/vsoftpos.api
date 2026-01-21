using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Pos.Core.Entidades.Seguridad;

public partial class Permiso
{
    [Key]
    public int Id { get; set; }

    public int RolId { get; set; }

    public int MenuId { get; set; }

    [ForeignKey("RolId")]
    [InverseProperty("Permiso")]
    public virtual Rol Rol { get; set; } = null!;
}
