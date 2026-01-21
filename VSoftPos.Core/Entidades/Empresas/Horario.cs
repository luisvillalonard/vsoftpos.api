using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Pos.Core.Entidades.Empresas;

public partial class Horario
{
    [Key]
    public int Id { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string Nombre { get; set; } = null!;

    [Precision(0)]
    public TimeSpan HoraInicio { get; set; }

    [Precision(0)]
    public TimeSpan HoraFin { get; set; }

    public int EmpresaId { get; set; }

    public bool Activo { get; set; }

    [InverseProperty("Horario")]
    public virtual ICollection<Empleado> Empleado { get; set; } = new List<Empleado>();

    [ForeignKey("EmpresaId")]
    [InverseProperty("Horario")]
    public virtual Empresa Empresa { get; set; } = null!;
}
