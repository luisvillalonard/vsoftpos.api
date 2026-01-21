using Pos.Core.Entidades.Compras;
using Pos.Core.Entidades.Empresas;
using Pos.Core.Entidades.Ventas;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Pos.Core.Entidades.Configuraciones;

public partial class CondicionPago
{
    [Key]
    public int Id { get; set; }

    [StringLength(100)]
    public string Nombre { get; set; } = null!;

    [StringLength(250)]
    public string? Descripcion { get; set; }

    public bool AplicaCliente { get; set; }

    public bool AplicaSuplidor { get; set; }

    public bool AlContado { get; set; }

    public int DiasVencimiento { get; set; }

    public bool Activo { get; set; }

    [InverseProperty("CondicionPago")]
    public virtual ICollection<Cliente> Cliente { get; set; } = new List<Cliente>();

    [InverseProperty("CondicionPago")]
    public virtual ICollection<Suplidor> Suplidor { get; set; } = new List<Suplidor>();
}
