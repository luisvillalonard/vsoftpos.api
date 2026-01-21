using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Pos.Core.Entidades.Ventas;

public partial class Credito
{
    [Key]
    public int Id { get; set; }

    public int ClienteId { get; set; }

    [Column(TypeName = "numeric(18, 2)")]
    public decimal Monto { get; set; }

    [Column(TypeName = "numeric(18, 2)")]
    public decimal Deuda { get; set; }

    [ForeignKey("ClienteId")]
    [InverseProperty("Credito")]
    public virtual Cliente Cliente { get; set; } = null!;
}
