using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Pos.Core.Entidades.Contabilidad;

public partial class Banco
{
    [Key]
    public int Id { get; set; }

    [StringLength(50)]
    public string Nombre { get; set; } = null!;

    [StringLength(250)]
    public string? Descripcion { get; set; }

    public bool Activo { get; set; }

    [InverseProperty("Banco")]
    public virtual ICollection<CuentaBanco> CuentaBanco { get; set; } = new List<CuentaBanco>();
}
