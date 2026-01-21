using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using Pos.Core.Entidades.Empresas;
using Pos.Core.Entidades.Seguridad;

namespace Pos.Core.Entidades.Ventas;

public partial class Cotizacion
{
    [Key]
    public int Id { get; set; }

    public int EmpresaId { get; set; }

    public int ClienteId { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime Fecha { get; set; }

    [Column(TypeName = "numeric(18, 2)")]
    public decimal SubTotal { get; set; }

    [Column(TypeName = "numeric(18, 2)")]
    public decimal Itbis { get; set; }

    [Column(TypeName = "numeric(18, 2)")]
    public decimal Descuento { get; set; }

    [Column(TypeName = "numeric(18, 2)")]
    public decimal Total { get; set; }

    [StringLength(500)]
    public string? Comentario { get; set; }

    public bool Abierta { get; set; }

    public bool Anulada { get; set; }

    [ForeignKey("ClienteId")]
    [InverseProperty("Cotizacion")]
    public virtual Cliente Cliente { get; set; } = null!;

    [InverseProperty("Cotizacion")]
    public virtual ICollection<CotizacionDetalle> CotizacionDetalle { get; set; } = new List<CotizacionDetalle>();

    [ForeignKey("EmpresaId")]
    [InverseProperty("Cotizacion")]
    public virtual Empresa Empresa { get; set; } = null!;
}
