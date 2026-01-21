using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Pos.Core.Entidades.Inventario;

public partial class AlmacenSalida
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
    [InverseProperty("AlmacenSalida")]
    public virtual Almacen Almacen { get; set; } = null!;

    [InverseProperty("Salida")]
    public virtual ICollection<AlmacenSalidaDetalle> AlmacenSalidaDetalle { get; set; } = new List<AlmacenSalidaDetalle>();
}
