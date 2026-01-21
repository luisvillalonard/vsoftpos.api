using Pos.Core.Entidades.Empresas;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Pos.Core.Entidades.Compras;

public partial class Gasto
{
    [Key]
    public int Id { get; set; }

    public int TipoId { get; set; }

    public DateTime Fecha { get; set; }

    [Column(TypeName = "numeric(18, 0)")]
    public decimal Monto { get; set; }

    public int? EmpleadoId { get; set; }

    [StringLength(250)]
    public string? Comentario { get; set; }

    public int EmpresaId { get; set; }

    public bool Anulado { get; set; }

    [ForeignKey("EmpleadoId")]
    [InverseProperty("Gasto")]
    public virtual Empleado? Empleado { get; set; }

    [ForeignKey("EmpresaId")]
    [InverseProperty("Gasto")]
    public virtual Empresa Empresa { get; set; } = null!;

    [ForeignKey("TipoId")]
    [InverseProperty("Gasto")]
    public virtual GastoTipo Tipo { get; set; } = null!;
}
