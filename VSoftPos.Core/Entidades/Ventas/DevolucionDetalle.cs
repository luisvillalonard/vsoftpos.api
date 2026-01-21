using Pos.Core.Entidades.Inventario;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Pos.Core.Entidades.Ventas;

public partial class DevolucionDetalle
{
    [Key]
    public long Id { get; set; }

    public long DevolucionId { get; set; }

    public int ProductoId { get; set; }

    [StringLength(100)]
    public string Producto { get; set; } = null!;

    public int CantidadFacturada { get; set; }

    public int CantidadDevolucion { get; set; }

    public int Orden { get; set; }

    [StringLength(500)]
    public string? Nota { get; set; }

    [ForeignKey("DevolucionId")]
    [InverseProperty("DevolucionDetalle")]
    public virtual Devolucion Devolucion { get; set; } = null!;

    [ForeignKey("ProductoId")]
    [InverseProperty("DevolucionDetalle")]
    public virtual Producto ProductoNavigation { get; set; } = null!;
}
