using Pos.Core.Entidades.Inventario;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Pos.Core.Entidades.Ventas;

public partial class FacturaDetalle
{
    [Key]
    public long Id { get; set; }

    public long FacturaId { get; set; }

    public int ProductoId { get; set; }

    [StringLength(100)]
    public string Producto { get; set; } = null!;

    [Column(TypeName = "numeric(18, 2)")]
    public decimal Monto { get; set; }

    public int Cantidad { get; set; }

    [Column(TypeName = "numeric(18, 2)")]
    public decimal Total { get; set; }

    [Column(TypeName = "numeric(18, 2)")]
    public decimal Itbis { get; set; }

    [Column(TypeName = "numeric(18, 2)")]
    public decimal Comision { get; set; }

    public int Orden { get; set; }

    public bool Cortesia { get; set; }

    [ForeignKey("FacturaId")]
    [InverseProperty("FacturaDetalle")]
    public virtual Factura Factura { get; set; } = null!;

    [ForeignKey("ProductoId")]
    [InverseProperty("FacturaDetalle")]
    public virtual Producto ProductoNavigation { get; set; } = null!;
}
