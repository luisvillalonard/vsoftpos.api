using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Pos.Core.Entidades.Inventario;

public partial class Medida
{
    [Key]
    public int Id { get; set; }

    [StringLength(50)]
    public string Nombre { get; set; } = null!;

    public bool Activa { get; set; }

    [InverseProperty("Medida")]
    public virtual ICollection<Unidad> Unidad { get; set; } = new List<Unidad>();
}
