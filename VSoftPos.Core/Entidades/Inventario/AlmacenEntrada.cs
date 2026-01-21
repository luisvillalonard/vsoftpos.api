using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Pos.Core.Entidades.Inventario;

public partial class AlmacenEntrada
{
    [Key]
    public int Id { get; set; }

    public int AlmacenId { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime Fecha { get; set; }

    [StringLength(500)]
    public string? Nota { get; set; }

    public bool Anulada { get; set; }

    [ForeignKey("AlmacenId")]
    [InverseProperty("AlmacenEntrada")]
    public virtual Almacen Almacen { get; set; } = null!;

    [InverseProperty("Entrada")]
    public virtual ICollection<AlmacenEntradaDetalle> AlmacenEntradaDetalle { get; set; } = new List<AlmacenEntradaDetalle>();
}
