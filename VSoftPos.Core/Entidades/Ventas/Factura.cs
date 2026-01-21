using Microsoft.EntityFrameworkCore;
using Pos.Core.Entidades.Configuraciones;
using Pos.Core.Entidades.Contabilidad;
using Pos.Core.Entidades.Empresas;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Pos.Core.Entidades.Ventas;

public partial class Factura
{
    [Key]
    public long Id { get; set; }

    public int Numero { get; set; }

    public int EmpresaId { get; set; }

    public int ClienteId { get; set; }

    public int FacturaTipoId { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime FechaEmision { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? FechaSaldo { get; set; }

    [Column(TypeName = "date")]
    public DateTime? FechaLimitePago { get; set; }

    [Column(TypeName = "date")]
    public DateTime? FechaEntrega { get; set; }

    [Column("NCF")]
    [StringLength(25)]
    [Unicode(false)]
    public string? Ncf { get; set; }

    public int? ComprobanteId { get; set; }

    [Column(TypeName = "numeric(18, 2)")]
    public decimal SubTotal { get; set; }

    [Column(TypeName = "numeric(18, 2)")]
    public decimal Itbis { get; set; }

    [Column(TypeName = "numeric(18, 2)")]
    public decimal Descuento { get; set; }

    [Column(TypeName = "numeric(18, 2)")]
    public decimal Total { get; set; }

    [Column(TypeName = "numeric(18, 2)")]
    public decimal Pagado { get; set; }

    [Column(TypeName = "numeric(18, 2)")]
    public decimal Devuelto { get; set; }

    [StringLength(500)]
    public string? Nota { get; set; }

    public bool Abierta { get; set; }

    public bool Anulada { get; set; }

    [ForeignKey("ClienteId")]
    [InverseProperty("Factura")]
    public virtual Cliente Cliente { get; set; } = null!;

    [ForeignKey("ComprobanteId")]
    [InverseProperty("Factura")]
    public virtual Comprobante? Comprobante { get; set; }

    [InverseProperty("Factura")]
    public virtual ICollection<Devolucion> Devolucion { get; set; } = new List<Devolucion>();

    [ForeignKey("EmpresaId")]
    [InverseProperty("Factura")]
    public virtual Empresa Empresa { get; set; } = null!;

    [InverseProperty("Factura")]
    public virtual ICollection<FacturaDetalle> FacturaDetalle { get; set; } = new List<FacturaDetalle>();

    [InverseProperty("Factura")]
    public virtual ICollection<FacturaNota> FacturaNota { get; set; } = new List<FacturaNota>();

    [InverseProperty("Factura")]
    public virtual ICollection<FacturaPago> FacturaPago { get; set; } = new List<FacturaPago>();

    [ForeignKey("FacturaTipoId")]
    [InverseProperty("Factura")]
    public virtual FacturaTipo FacturaTipo { get; set; } = null!;
}
