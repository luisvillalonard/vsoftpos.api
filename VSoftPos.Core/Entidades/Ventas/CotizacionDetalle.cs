using Pos.Core.Entidades.Inventario;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Pos.Core.Entidades.Ventas;

public partial class CotizacionDetalle
{
    [Key]
    public int Id { get; set; }

    public int CotizacionId { get; set; }

    public int ProductoId { get; set; }

    [StringLength(100)]
    public string Producto { get; set; } = null!;

    [Column(TypeName = "numeric(18, 0)")]
    public decimal Monto { get; set; }

    public int Cantidad { get; set; }

    [Column(TypeName = "numeric(18, 0)")]
    public decimal Total { get; set; }

    [Column(TypeName = "numeric(18, 0)")]
    public decimal Itbis { get; set; }

    public int Orden { get; set; }

    [ForeignKey("CotizacionId")]
    [InverseProperty("CotizacionDetalle")]
    public virtual Cotizacion Cotizacion { get; set; } = null!;

    [ForeignKey("ProductoId")]
    [InverseProperty("CotizacionDetalle")]
    public virtual Producto ProductoNavigation { get; set; } = null!;
}
