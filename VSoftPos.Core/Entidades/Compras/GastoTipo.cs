using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Pos.Core.Entidades.Compras;

public partial class GastoTipo
{
    [Key]
    public int Id { get; set; }

    [StringLength(50)]
    public string Nombre { get; set; } = null!;

    [StringLength(150)]
    public string? Descripcion { get; set; }

    public bool Activo { get; set; }

    [InverseProperty("Tipo")]
    public virtual ICollection<Gasto> Gasto { get; set; } = new List<Gasto>();
}
