using Pos.Core.Entidades.Seguridad;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Pos.Core.Entidades.Empresas;

public partial class Posicion
{
    [Key]
    public int Id { get; set; }

    public int EmpresaId { get; set; }

    [StringLength(100)]
    public string Nombre { get; set; } = null!;

    [StringLength(250)]
    public string? Descripcion { get; set; }

    [Column(TypeName = "numeric(18, 2)")]
    public decimal Sueldo { get; set; }

    public bool Activa { get; set; }

    [InverseProperty("Posicion")]
    public virtual ICollection<Empleado> Empleado { get; set; } = new List<Empleado>();

    [ForeignKey("EmpresaId")]
    [InverseProperty("Posicion")]
    public virtual Empresa Empresa { get; set; } = null!;
}
