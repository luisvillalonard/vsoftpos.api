using Pos.Core.Entidades.Ventas;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Pos.Core.Entidades.Configuraciones;

public partial class FormaPago
{
    [Key]
    public int Id { get; set; }

    [StringLength(50)]
    public string Nombre { get; set; } = null!;

    [StringLength(200)]
    public string? Descripcion { get; set; }

    public bool Primaria { get; set; }

    public bool AplicaEnFactura { get; set; }

    public bool AplicaEnCuadre { get; set; }

    public bool Referencia { get; set; }

    public bool Activa { get; set; }

    [InverseProperty("FormaPago")]
    public virtual ICollection<CuadrePago> CuadrePago { get; set; } = new List<CuadrePago>();

    [InverseProperty("FormaPago")]
    public virtual ICollection<FacturaPago> FacturaPago { get; set; } = new List<FacturaPago>();
}
