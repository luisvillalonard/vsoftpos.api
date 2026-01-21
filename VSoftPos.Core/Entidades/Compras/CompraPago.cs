using Microsoft.EntityFrameworkCore;
using Pos.Core.Entidades.Seguridad;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Pos.Core.Entidades.Compras;

public partial class CompraPago
{
    [Key]
    public int Id { get; set; }

    public int CompraId { get; set; }

    [Column(TypeName = "numeric(18, 2)")]
    public decimal Monto { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime Fecha { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? NumeroRecibo { get; set; }

    public bool Anulado { get; set; }

    [ForeignKey("CompraId")]
    [InverseProperty("CompraPago")]
    public virtual Compra Compra { get; set; } = null!;
}
