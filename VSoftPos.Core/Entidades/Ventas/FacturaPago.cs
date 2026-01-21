using Microsoft.EntityFrameworkCore;
using Pos.Core.Entidades.Configuraciones;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Pos.Core.Entidades.Ventas;

public partial class FacturaPago
{
    [Key]
    public long Id { get; set; }

    public long FacturaId { get; set; }

    public int FormaPagoId { get; set; }

    [Column(TypeName = "numeric(18, 2)")]
    public decimal Monto { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime Fecha { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? Numero { get; set; }

    [ForeignKey("FacturaId")]
    [InverseProperty("FacturaPago")]
    public virtual Factura Factura { get; set; } = null!;

    [ForeignKey("FormaPagoId")]
    [InverseProperty("FacturaPago")]
    public virtual FormaPago FormaPago { get; set; } = null!;
}
