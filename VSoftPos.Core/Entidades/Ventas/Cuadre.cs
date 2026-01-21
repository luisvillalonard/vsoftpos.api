using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Pos.Core.Entidades.Ventas;

public partial class Cuadre
{
    [Key]
    public long Id { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime Fecha { get; set; }

    [Column(TypeName = "decimal(18, 2)")]
    public decimal MontoInicio { get; set; }

    public int CantidadCerradas { get; set; }

    public int CantidadAbiertas { get; set; }

    public int CantidadAnuladas { get; set; }

    [Column(TypeName = "numeric(18, 0)")]
    public decimal MontoFacturas { get; set; }

    [Column(TypeName = "numeric(18, 0)")]
    public decimal MontoCuadre { get; set; }

    [Column(TypeName = "numeric(18, 0)")]
    public decimal MontoFaltante { get; set; }

    [Column(TypeName = "numeric(18, 0)")]
    public decimal MontoSobrante { get; set; }

    [Column(TypeName = "numeric(18, 0)")]
    public decimal MontoGastos { get; set; }

    public bool Abierta { get; set; }

    [StringLength(500)]
    public string? Comentario { get; set; }

    [InverseProperty("Cuadre")]
    public virtual ICollection<CuadreBillete> CuadreBillete { get; set; } = new List<CuadreBillete>();

    [InverseProperty("Cuadre")]
    public virtual ICollection<CuadrePago> CuadrePago { get; set; } = new List<CuadrePago>();
}
