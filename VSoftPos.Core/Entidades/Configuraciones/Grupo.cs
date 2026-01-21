using Pos.Core.Entidades.Inventario;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Pos.Core.Entidades.Configuraciones;

public partial class Grupo
{
    [Key]
    public int Id { get; set; }

    [StringLength(50)]
    public string Nombre { get; set; } = null!;

    [StringLength(200)]
    public string? Descripcion { get; set; }

    public bool Cliente { get; set; }

    public bool Suplidor { get; set; }

    public bool Producto { get; set; }

    public bool Servicio { get; set; }

    public bool Activo { get; set; }

    [InverseProperty("Grupo")]
    public virtual ICollection<Producto> ProductoNavigation { get; set; } = new List<Producto>();
}
