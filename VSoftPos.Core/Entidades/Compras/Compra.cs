using Microsoft.EntityFrameworkCore;
using Pos.Core.Entidades.Empresas;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Pos.Core.Entidades.Compras;

public partial class Compra
{
    [Key]
    public int Id { get; set; }

    [Column(TypeName = "date")]
    public DateTime Fecha { get; set; }

    [StringLength(25)]
    [Unicode(false)]
    public string NumeroFactura { get; set; } = null!;

    public int SuplidorId { get; set; }

    public int EmpresaId { get; set; }

    [Column(TypeName = "date")]
    public DateTime? FechaLimite { get; set; }

    public bool Pagada { get; set; }

    [Column(TypeName = "numeric(18, 2)")]
    public decimal MontoFactura { get; set; }

    [Column(TypeName = "numeric(18, 2)")]
    public decimal MontoPagado { get; set; }

    public bool Anulada { get; set; }

    [InverseProperty("Compra")]
    public virtual ICollection<CompraDetalle> CompraDetalle { get; set; } = new List<CompraDetalle>();

    [InverseProperty("Compra")]
    public virtual ICollection<CompraPago> CompraPago { get; set; } = new List<CompraPago>();

    [ForeignKey("EmpresaId")]
    [InverseProperty("Compra")]
    public virtual Empresa Empresa { get; set; } = null!;

    [ForeignKey("SuplidorId")]
    [InverseProperty("Compra")]
    public virtual Suplidor Suplidor { get; set; } = null!;
}
