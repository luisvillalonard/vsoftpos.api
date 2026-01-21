using Microsoft.EntityFrameworkCore;
using Pos.Core.Entidades.Compras;
using Pos.Core.Entidades.Inventario;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Pos.Core.Entidades.Contabilidad;

public partial class Impuesto
{
    [Key]
    public int Id { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string Codigo { get; set; } = null!;

    [StringLength(50)]
    [Unicode(false)]
    public string? Nombre { get; set; }

    [Column(TypeName = "numeric(6, 2)")]
    public decimal Tasa { get; set; }

    public bool Activo { get; set; }

    [InverseProperty("Impuesto")]
    public virtual ICollection<CompraDetalle> CompraDetalle { get; set; } = new List<CompraDetalle>();

    [InverseProperty("Impuesto")]
    public virtual ICollection<Producto> Producto { get; set; } = new List<Producto>();
}
