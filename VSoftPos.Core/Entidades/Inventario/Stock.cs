using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Pos.Core.Entidades.Inventario;

public partial class Stock
{
    [Key]
    public int Id { get; set; }

    public int ProductoId { get; set; }

    public int AlmacenId { get; set; }

    public int Cantidad { get; set; }

    public int Fraccion { get; set; }

    [ForeignKey("AlmacenId")]
    [InverseProperty("Stock")]
    public virtual Almacen Almacen { get; set; } = null!;

    [ForeignKey("ProductoId")]
    [InverseProperty("Stock")]
    public virtual Producto Producto { get; set; } = null!;
}
