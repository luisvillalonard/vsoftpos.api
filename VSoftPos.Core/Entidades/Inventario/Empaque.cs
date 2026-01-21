using Pos.Core.Entidades.Compras;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Pos.Core.Entidades.Inventario;

public partial class Empaque
{
    [Key]
    public int Id { get; set; }

    [StringLength(100)]
    public string Nombre { get; set; } = null!;

    public int Unidades { get; set; }

    public bool Activo { get; set; }

    [InverseProperty("Empaque")]
    public virtual ICollection<CompraDetalle> CompraDetalle { get; set; } = new List<CompraDetalle>();
}
