using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Pos.Core.Entidades.Inventario;

public partial class AlmacenSalidaDetalle
{
    [Key]
    public int Id { get; set; }

    public int SalidaId { get; set; }

    public int ProductoId { get; set; }

    public int Cantidad { get; set; }

    [Column(TypeName = "numeric(18, 0)")]
    public decimal Precio { get; set; }

    [Column(TypeName = "numeric(18, 0)")]
    public decimal Itbis { get; set; }

    [Column(TypeName = "numeric(18, 0)")]
    public decimal Total { get; set; }

    [ForeignKey("ProductoId")]
    [InverseProperty("AlmacenSalidaDetalle")]
    public virtual Producto Producto { get; set; } = null!;

    [ForeignKey("SalidaId")]
    [InverseProperty("AlmacenSalidaDetalle")]
    public virtual AlmacenSalida Salida { get; set; } = null!;
}
