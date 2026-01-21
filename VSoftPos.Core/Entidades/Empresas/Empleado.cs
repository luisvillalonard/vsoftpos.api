using Microsoft.EntityFrameworkCore;
using Pos.Core.Entidades.Auxiliares;
using Pos.Core.Entidades.Compras;
using Pos.Core.Entidades.Seguridad;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Pos.Core.Entidades.Empresas;

public partial class Empleado
{
    [Key]
    public int Id { get; set; }

    [StringLength(200)]
    public string Nombre { get; set; } = null!;

    public bool Femenino { get; set; }

    [StringLength(11)]
    [Unicode(false)]
    public string? Cedula { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? Pasaporte { get; set; }

    public int? PosicionId { get; set; }

    [Column(TypeName = "numeric(18, 2)")]
    public decimal? Salario { get; set; }

    public int EmpresaId { get; set; }

    public int? HorarioId { get; set; }

    public long? FotoId { get; set; }

    public DateOnly? FechaEntrada { get; set; }

    public DateOnly? FechaSalida { get; set; }

    [StringLength(150)]
    [Unicode(false)]
    public string? Correo { get; set; }

    public bool Activo { get; set; }

    [ForeignKey("EmpresaId")]
    [InverseProperty("Empleado")]
    public virtual Empresa Empresa { get; set; } = null!;

    [InverseProperty("Empleado")]
    public virtual ICollection<Gasto> Gasto { get; set; } = new List<Gasto>();

    [ForeignKey("HorarioId")]
    [InverseProperty("Empleado")]
    public virtual Horario? Horario { get; set; }

    [ForeignKey("PosicionId")]
    [InverseProperty("Empleado")]
    public virtual Posicion? Posicion { get; set; }

    [InverseProperty("Empleado")]
    public virtual ICollection<Usuario> Usuario { get; set; } = new List<Usuario>();
}
