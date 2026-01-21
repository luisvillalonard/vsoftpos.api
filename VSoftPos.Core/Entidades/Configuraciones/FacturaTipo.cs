using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Pos.Core.Entidades.Ventas;

namespace Pos.Core.Entidades.Configuraciones;

public partial class FacturaTipo
{
    [Key]
    public int Id { get; set; }

    [StringLength(50)]
    public string Descripcion { get; set; } = null!;

    public bool Primaria { get; set; }

    public bool RequiereMonto { get; set; }

    [InverseProperty("FacturaTipo")]
    public virtual ICollection<Factura> Factura { get; set; } = new List<Factura>();
}
