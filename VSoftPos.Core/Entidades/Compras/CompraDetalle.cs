using Pos.Core.Entidades.Contabilidad;
using Pos.Core.Entidades.Inventario;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Pos.Core.Entidades.Compras;

public partial class CompraDetalle
{
    [Key]
    public int Id { get; set; }

    public int CompraId { get; set; }

    public int ProductoId { get; set; }

    public int EmpaqueId { get; set; }

    public int Cantidad { get; set; }

    [Column(TypeName = "numeric(18, 0)")]
    public decimal Precio { get; set; }

    public int ImpuestoId { get; set; }

    [Column(TypeName = "numeric(18, 0)")]
    public decimal Monto { get; set; }

    public int AlmacenId { get; set; }

    [ForeignKey("AlmacenId")]
    [InverseProperty("CompraDetalle")]
    public virtual Almacen Almacen { get; set; } = null!;

    [ForeignKey("CompraId")]
    [InverseProperty("CompraDetalle")]
    public virtual Compra Compra { get; set; } = null!;

    [ForeignKey("EmpaqueId")]
    [InverseProperty("CompraDetalle")]
    public virtual Empaque Empaque { get; set; } = null!;

    [ForeignKey("ImpuestoId")]
    [InverseProperty("CompraDetalle")]
    public virtual Impuesto Impuesto { get; set; } = null!;

    [ForeignKey("ProductoId")]
    [InverseProperty("CompraDetalle")]
    public virtual Producto Producto { get; set; } = null!;
}
