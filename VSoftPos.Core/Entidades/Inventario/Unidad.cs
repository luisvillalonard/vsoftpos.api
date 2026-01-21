using Pos.Core.Entidades.Seguridad;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Pos.Core.Entidades.Inventario;

public partial class Unidad
{
    [Key]
    public int Id { get; set; }

    [StringLength(50)]
    public string Descripcion { get; set; } = null!;

    public int MedidaId { get; set; }

    public bool Activa { get; set; }

    [ForeignKey("MedidaId")]
    [InverseProperty("Unidad")]
    public virtual Medida Medida { get; set; } = null!;
}
