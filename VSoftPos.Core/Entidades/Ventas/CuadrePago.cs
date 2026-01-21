using Microsoft.EntityFrameworkCore;
using Pos.Core.Entidades.Configuraciones;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Pos.Core.Entidades.Ventas;

public partial class CuadrePago
{
    [Key]
    public long Id { get; set; }

    public long CuadreId { get; set; }

    public int FormaPagoId { get; set; }

    [Column(TypeName = "numeric(18, 2)")]
    public decimal Monto { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? Referencia { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime Fecha { get; set; }

    [ForeignKey("CuadreId")]
    [InverseProperty("CuadrePago")]
    public virtual Cuadre Cuadre { get; set; } = null!;

    [ForeignKey("FormaPagoId")]
    [InverseProperty("CuadrePago")]
    public virtual FormaPago FormaPago { get; set; } = null!;
}
