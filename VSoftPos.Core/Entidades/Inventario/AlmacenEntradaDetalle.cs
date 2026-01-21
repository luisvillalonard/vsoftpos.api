using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Pos.Core.Entidades.Inventario;

public partial class AlmacenEntradaDetalle
{
    [Key]
    public int Id { get; set; }

    public int EntradaId { get; set; }

    public int ProductoId { get; set; }

    public int Cantidad { get; set; }

    [Column(TypeName = "numeric(18, 0)")]
    public decimal Precio { get; set; }

    [Column(TypeName = "numeric(18, 0)")]
    public decimal Itbis { get; set; }

    [Column(TypeName = "numeric(18, 0)")]
    public decimal Total { get; set; }

    [ForeignKey("EntradaId")]
    [InverseProperty("AlmacenEntradaDetalle")]
    public virtual AlmacenEntrada Entrada { get; set; } = null!;

    [ForeignKey("ProductoId")]
    [InverseProperty("AlmacenEntradaDetalle")]
    public virtual Producto Producto { get; set; } = null!;
}
